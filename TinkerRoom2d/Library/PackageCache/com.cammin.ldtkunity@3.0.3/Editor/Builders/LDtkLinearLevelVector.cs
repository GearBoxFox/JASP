﻿namespace LDtkUnity.Editor
{
    internal class LDtkLinearLevelVector
    {
        private const int SPACED_TILES = 48;

        public int Scaler { get; private set; } = 0;
        
        public void Next(int lvlPx)
        {
            int newValue = Scaler + lvlPx + SPACED_TILES;
            //Debug.Log($"TotalAdd from {Scaler} to {newValue}");
            Scaler = newValue;
        }
    }
}