﻿using UnityEditor;
using UnityEngine;

namespace LDtkUnity.Editor
{
    /// <summary>
    /// Reminder: Responsibility is just for drawing the Header content and and other unique functionality. All of the numerous content is handled in the Reference Drawers
    /// </summary>
    internal abstract class LDtkSectionDrawer : ILDtkSectionDrawer
    {
        protected readonly SerializedObject SerializedObject;
        private bool _dropdown;

        protected abstract string GuiText { get; }
        protected abstract string GuiTooltip { get; }
        protected abstract Texture GuiImage { get; }
        protected abstract string ReferenceLink { get; }
        
        public bool HasResizedArrayPropThisUpdate { get; protected set; } = false;

        protected LDtkProjectImporter Importer => (LDtkProjectImporter)SerializedObject?.targetObject;
        public virtual bool HasProblem => false;
        protected virtual bool SupportsMultipleSelection => false; 
        

        protected LDtkSectionDrawer(SerializedObject serializedObject)
        {
            SerializedObject = serializedObject;
        }

        public virtual void Init()
        {
            _dropdown = EditorPrefs.GetBool(GetType().Name, true);
        }
        
        public virtual void Dispose()
        {
            EditorPrefs.SetBool(GetType().Name, _dropdown);
        }
        
        public void Draw()
        {
            DrawFoldoutArea();

            if (TryDrawDropdown())
            {
                DrawDropdownContent();
            }
        }
        protected bool TryDrawDropdown()
        {
            return _dropdown;
        }

        private static void DrawSectionProblem(Rect controlRect)
        {
            float dimension = controlRect.height - 2;
            Rect errorArea = new Rect(controlRect)
            {
                x = controlRect.x + EditorGUIUtility.labelWidth - dimension + 1,
                y = controlRect.y +1,
                width = dimension,
                height = dimension
            };

            GUIContent tooltipContent = new GUIContent()
            {
                tooltip = "Expand this section to view the error"
            };
            
            GUI.Label(errorArea, tooltipContent);
            GUI.DrawTexture(errorArea, EditorGUIUtility.IconContent("console.warnicon.sml").image);
        }

        protected void DrawFoldoutArea()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                DrawFoldout();
                if (!string.IsNullOrEmpty(ReferenceLink))
                {
                    LDtkEditorGUI.DrawHelpIcon(ReferenceLink, GuiText);
                }
            }
        }

        private void DrawFoldout()
        {
            GUIContent content = new GUIContent()
            {
                text = GuiText,
                tooltip = GuiTooltip,
                image = GuiImage
            };

            //Rect foldoutRect = controlRect;
            //foldoutRect.xMax -= 20;

            GUIStyle style = EditorStyles.foldoutHeader;
            _dropdown = EditorGUILayout.Foldout(_dropdown, content, style);
        }

        protected virtual void DrawDropdownContent()
        {
            
        }
    }
}