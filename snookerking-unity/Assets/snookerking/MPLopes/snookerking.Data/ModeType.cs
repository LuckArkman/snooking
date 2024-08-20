using System;
using UnityEngine;

namespace snookerking.Data
{
    [Serializable]
    public class ModeType
    {
        public ModeType(){}
        
        public int modeType;
        public string targetScreen;
        public bool save;

        public int MODE_TYPE
        {
            get => modeType;
            set => modeType = value;
        }
    }
}