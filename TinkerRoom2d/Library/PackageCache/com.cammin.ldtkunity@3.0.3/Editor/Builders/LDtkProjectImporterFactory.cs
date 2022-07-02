﻿using UnityEngine;

namespace LDtkUnity.Editor
{
    internal class LDtkProjectImporterFactory
    {
        private readonly LDtkProjectImporter _importer;

        public LDtkProjectImporterFactory(LDtkProjectImporter importer)
        {
            _importer = importer;
        }

        public void Import(LdtkJson json)
        {
            //set the data class's levels correctly, regardless if they are external levels or not
            RestructureJson(json);
            
            LDtkProjectBuilder builder = new LDtkProjectBuilder(_importer, json);
            builder.BuildProject();
            GameObject projectGameObject = builder.RootObject;

            if (projectGameObject == null)
            {
                _importer.ImportContext.LogImportError("LDtk: Project GameObject null, not building correctly");
                return;
            }
            
            _importer.ImportContext.AddObjectToAsset("rootGameObject", projectGameObject, LDtkIconUtility.LoadProjectFileIcon());
            _importer.ImportContext.SetMainObject(projectGameObject);
        }
        
        private void RestructureJson(LdtkJson project)
        {
            //we wanna modify the json and serialize it back to that it's usable later with it's completeness regardless of external levels
            LDtkJsonRestructure.Restructure(project, _importer.assetPath);

            string newJson = "";
            try
            {
                newJson = project.ToJson();
            }
            finally
            {
                _importer.JsonFile.SetJson(newJson);
            }
        }
    }
}