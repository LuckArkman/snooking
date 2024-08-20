using UnityEngine;

namespace snookerking.Singletons
{
    public class Singleton
    {
        public GameObject _camera;
        public GameObject _taco;
        public GameObject _strength;
        
        static Singleton _instance;

        public static Singleton _Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                    return _instance;
                }
                return _instance;
            }
        }
    }
}