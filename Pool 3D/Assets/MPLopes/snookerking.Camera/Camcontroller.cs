using System.Runtime.InteropServices;
using snookerking.Enums;
using UnityEngine;

namespace snookerking.Camera
{
    public class Camcontroller : CameraData
    {
        void Start()
        {
            _taco.head = head.transform;
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
             Vector3 direction = new Vector3(0, height, -distance);
             
             Quaternion rotation = Quaternion.Euler(0, 0.0f, 0);
             this.transform.position = Vector3.SmoothDamp(this.transform.position, headPos(rotation, direction),ref posVel, smooth_position);
        }

        void FixedUpdate()
        {
            OnUpdateCam();
            //if (Input.GetMouseButton(0)) _mouseAction = MouseAction.Click;
            //if (Input.GetMouseButton(1)) _mouseAction = MouseAction.None;
            //if(_camTypes == CamTypes.None)transform.LookAt(GetLookState());
            /*
            if(_camTypes == CamTypes.Top)transform.LookAt(GetLookStateTop());
            aiTaco.SetActive(_camTypes == CamTypes.aiPoint);
            _taco.OnSetType(_camTypes);
            if(showTaco && _camTypes == CamTypes.None && !_strength.strength) 
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
            if(showTaco)
            */
            if (!head.aiPlaying && head.stopBalls)
            {
                _camTypes = CamTypes.None;
                _taco.head = head.transform;
                _taco.height = tacogameheight;
                _taco.OnPosition();
                aiTaco.SetActive(false);
                return;
            }
            if (!head.aiPlaying && !head.stopBalls)
            {
                _camTypes = CamTypes.aiPoint;
                _taco.head = repouso.transform;
                _taco.height = tacorepousoheight;
                _taco.OnPosition();
                aiTaco.SetActive(false);
                return;
            }
            if (head.aiPlaying && head.stopBalls)
            {
                _camTypes = CamTypes.aiPoint;
                _taco.head = repouso.transform;
                _taco.height = tacorepousoheight;
                _taco.OnPosition();
                aiTaco.SetActive(true);
                return;
            }
            if (head.aiPlaying && !head.stopBalls)
            {
                _camTypes = CamTypes.aiPoint;
                _taco.head = repouso.transform;
                _taco.height = tacorepousoheight;
                _taco.OnPosition();
                aiTaco.SetActive(true);
            }
        }

        private Vector3 GetLookStateTop()
        => Vector3.SmoothDamp(this.transform.position, this.lookcenter.position,ref lookVel, smooth);

        private void OnUpdateCam()
        {
            /*
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            if (Input.GetMouseButtonUp(0))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            */
            if (Input.GetMouseButton(0) && _camTypes == CamTypes.None)
            {
                rotx += Input.GetAxis("Mouse X") * inputSense * Time.deltaTime;
                roty += Input.GetAxis("Mouse Y") * inputSense * Time.deltaTime;
                _taco.rotx = rotx;
                _taco.roty = roty;
            }
            if (_camTypes == CamTypes.Top)
            {
                this.transform.position = Vector3.SmoothDamp(this.transform.position, topposition.position,
                    ref posVel, smooth_position);
            }
            if (_camTypes == CamTypes.None)
            {
                transform.LookAt(GetLookState());
                Vector3 direction = new Vector3(0, height, -distance);
                Quaternion rotation = Quaternion.Euler(0, rotx, 0);
                this.transform.position = Vector3.SmoothDamp(this.transform.position, headPos(rotation, direction),ref posVel, smooth_position);
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
            return this.head.transform.position + rotation * direction;
        }
        private Vector3 GetLookState()
        {
            return Vector3.SmoothDamp(this.transform.position, this.head.transform.position,ref lookVel, smooth);
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