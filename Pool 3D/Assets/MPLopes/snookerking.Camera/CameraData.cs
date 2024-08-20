using snookerking.Core;
using snookerking.Enums;
using UnityEngine;
using snookerking.Tacos;

namespace snookerking.Camera
{
    public class CameraData : MonoBehaviour
    {
        public CamTypes _camTypes;
        public bool showTaco, aiPoint;
        public Taco _taco;
        public GameObject taco, aiTaco, repouso;
        [Range(0.0f, 100.0f)]
        public float tacorepousoheight, tacogameheight;
        public MouseAction _mouseAction = MouseAction.None;
        public Transform topposition, lookcenter, _aiPoint, iPoint;
        public Strength _strength;
        public mainScript head;
        //public GameObject camera;
        [Range(0.0f, 100.0f)]
        public float inputSense = 3.0f;
        [Range(0.0f, 100.0f)]
        public float height = 3.0f;
        public float roty = 0.0f;
        public float rotx = 0.0f;
        public Vector3 lookVel = Vector3.zero;
        public Vector3 posVel = Vector3.zero;
        [Range(0.00f, 10.0f)]
        public float smooth = 0.5f;
        [Range(0.00f, 10.0f)]
        public float smooth_position = 0.025f;
        public const float YMin = -50.0f;
        public const float YMax = 50.0f;
        [Range(0.0f, 20.0f)]
        public float distance = 2.0f;
    }
}