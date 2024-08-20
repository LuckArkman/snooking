
using UnityEngine;
using UnityEngine.UI;

namespace snookerking.Core
{
    public class Strength : MonoBehaviour
    {
        public bool strength;

        public Image _image;

        public void OnStreaght()
        {
            strength = !strength;
        }

        private void Update()
        {
            strength = _image.fillAmount > 0.05f;
        }
    }
}