using snookerking.Enums;
using UnityEngine;

namespace snookerking.Tacos
{
    public class TacoDao : MonoBehaviour
    {
        public Transform _transform;
        public CamTypes _camTypes;
        public Transform head;
        [Range(0.0f, 100.0f)]
        public float inputSense = 3.0f;
        public float roty = 0.0f;
        public float rotx = 0.0f;
        [Range(-0.5f, 0.5f)]
        public float direcx = 0.0f;
        public Vector3 lookVel = Vector3.zero;
        public Vector3 posVel = Vector3.zero;
        [Range(0.00f, 10.0f)]
        public float smooth = 0.5f;
        [Range(0.00f, 10.0f)]
        public float smooth_position = 0.025f;
        public const float YMin = -50.0f;
        public const float YMax = 50.0f;
        [Range(0.0f, 20.0f)]
        public float distance = 1.0f;
        public Vector3 direction = Vector3.zero;
        public Vector3 rotation = Vector3.zero;
    }
}