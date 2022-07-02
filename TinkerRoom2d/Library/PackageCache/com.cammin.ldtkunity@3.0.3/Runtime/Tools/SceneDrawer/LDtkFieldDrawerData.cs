﻿using System;
using UnityEngine;

namespace LDtkUnity
{
    [Serializable]
    internal class LDtkFieldDrawerData : LDtkSceneDrawerBase
    {
        [SerializeField] private LDtkFields _fields;
        [SerializeField] private EditorDisplayMode _fieldMode;
        [SerializeField] private  int _gridSize;
        [SerializeField] private Vector3 _middleCenter;
        
        public LDtkFields Fields => _fields;
        public EditorDisplayMode FieldMode => _fieldMode;
        public int GridSize => _gridSize;
        public Vector3 MiddleCenter => _middleCenter;

        public LDtkFieldDrawerData(LDtkFields fields, Color smartColor, EditorDisplayMode fieldMode, string identifier, int gridSize, Vector3 middleCenter) : base(identifier, smartColor)
        {
            _fields = fields;
            _fieldMode = fieldMode;
            _gridSize = gridSize;
            _middleCenter = middleCenter;
        }
    }
}