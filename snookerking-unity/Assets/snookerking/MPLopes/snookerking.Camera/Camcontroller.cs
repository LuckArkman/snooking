using System.Runtime.InteropServices;
using snookerking.Enums;
using UnityEngine;
using UnityEngine.InputSystem;

namespace snookerking.Camera
{
    public class Camcontroller : CameraData
    {
        void Start()
        {
            camera = this.gameObject;
            StarPosition();
        }
        /*
        [DllImport("__Internal")]
        private static extern void SendMessageToJS(string message);
        public static void SetPlayerName(string name)
        {
            Debug.Log("Player name set to: " + name);
        }
        public void SendMessageToJavaScript()
        {
            SendMessageToJS("Hello from Unity!");
        }
        */
        private void StarPosition()
        {
            _taco.OnStartPosition(head);
             Vector3 direction = new Vector3(0, 8f, -distance);
             
             Quaternion rotation = Quaternion.Euler(0, 0.0f, 0);
             this.transform.position = Vector3.SmoothDamp(this.transform.position, headPos(rotation, direction),ref posVel, smooth_position);
        }

        void FixedUpdate()
        {
            //if (Input.GetMouseButton(0)) _mouseAction = MouseAction.Click;
            //if (Input.GetMouseButton(1)) _mouseAction = MouseAction.None;
            //if(_camTypes == CamTypes.None)transform.LookAt(GetLookState());
            if(_camTypes == CamTypes.Top)transform.LookAt(GetLookStateTop());
            aiTaco.SetActive(_camTypes == CamTypes.aiPoint);
            _taco.OnSetType(_camTypes);
            if(showTaco && _camTypes == CamTypes.None && !_strength.strength) OnUpdateCam();
            if(!showTaco) taco.SetActive(showTaco);
            if (!showTaco && _camTypes == CamTypes.None)
            {
                transform.LookAt(iPoint);
                this.transform.position = Vector3.SmoothDamp(this.transform.position, _aiPoint.position,
                    ref posVel, smooth_position);
            }
            if (!showTaco && _camTypes == CamTypes.aiPoint)
            {
                transform.LookAt(iPoint);
                this.transform.position = Vector3.SmoothDamp(this.transform.position, _aiPoint.position,
                    ref posVel, smooth_position);
            }
            if(showTaco) taco.SetActive(showTaco);
            if(showTaco)_taco.OnPosition(head);
        }

        private Vector3 GetLookStateTop()
        => Vector3.SmoothDamp(this.transform.position, this.lookcenter.position,ref lookVel, smooth);

        private void OnUpdateCam()
        {
            if (Input.GetMouseButton(0) && _camTypes == CamTypes.None)
            {
                rotx += Mouse.current.delta.ReadValue().x * inputSense * Time.deltaTime;
                roty += Mouse.current.delta.ReadValue().y * inputSense * Time.deltaTime;
            }
            if (_camTypes == CamTypes.Top)
            {
                this.transform.position = Vector3.SmoothDamp(this.transform.position, topposition.position,
                    ref posVel, smooth_position);
            }
            if (_camTypes == CamTypes.None)
            {
                transform.LookAt(GetLookState());
                Vector3 direction = new Vector3(0, 8f, -distance);
                Quaternion rotation = Quaternion.Euler(0, rotx, 0);
                if (showTaco)
                {
                    this.transform.position = Vector3.SmoothDamp(this.transform.position, headPos(rotation, direction),
                        ref posVel, smooth_position);
                }
            }
            if (_camTypes == CamTypes.aiPoint)
            {
                transform.LookAt(iPoint);
                this.transform.position = Vector3.SmoothDamp(this.transform.position, _aiPoint.position,
                    ref posVel, smooth_position);
            }
        }
        private Vector3 headPos(Quaternion rotation, Vector3 direction)
        {
            return this.head.position + rotation * direction;
        }
        private Vector3 GetLookState()
        {
            return Vector3.SmoothDamp(this.transform.position, this.head.position,ref lookVel, smooth);
        }

        public void OnCam()
        {
            Debug.Log(nameof(OnCam));
            switch (_camTypes)
            {
                case CamTypes.Top:
                {
                    _camTypes = CamTypes.None;
                    break;
                }
                case CamTypes.None:
                {
                    _camTypes = CamTypes.Top;
                    break;
                }
            }
        }
    }
}