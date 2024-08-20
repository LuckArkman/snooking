using System;
using UnityEngine;

namespace snookerking.Data
{
    [Serializable]
    public class GameMode
    {
        public GameMode(){}
        
        public int _gameMode;

        public string targetScreen;
        public bool save;

        public int Game_Mode
        {
            get => _gameMode;
            set => _gameMode = value;
        }
    }
}