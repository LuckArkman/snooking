using snookerking.Enums;
using UnityEngine;
using UnityEngine.InputSystem;

namespace snookerking.Tacos
{
    public class Taco : TacoDao
    {
        public void OnPosition(Transform _head)
        {
            transform.LookAt(GetLookState());
            if (Input.GetMouseButton(0))
            {
                rotx += Mouse.current.delta.ReadValue().x * inputSense * Time.deltaTime;
                roty += Mouse.current.delta.ReadValue().y * inputSense * Time.deltaTime;
                roty = Mathf.Clamp(roty, YMin, YMax);
            }
            Vector3 direction = new Vector3(direcx, 0.7f, -distance);
            Vector3 rotation = new Vector3(0, rotx, 0);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, headPos(Quaternion.Euler(rotation), direction), ref posVel, smooth_position);
        }
        
        Vector3 headPos(Quaternion rotation, Vector3 direction)
        => head.position + rotation * direction;
        
        Vector3 GetLookState()
        => Vector3.SmoothDamp(this.transform.position, this.head.position,ref lookVel, smooth);

        public void OnStartPosition(Transform _head)
        {
            if (head == null) head = _head;
            Vector3 direction = new Vector3(0, 0.7f, -distance);
            Quaternion rotation = Quaternion.Euler(0, 0.0f, 0);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, headPos(rotation, direction),ref posVel, smooth_position);
        }

        public void OnSetType(CamTypes camTypes)
            => _camTypes = camTypes;
    }
}