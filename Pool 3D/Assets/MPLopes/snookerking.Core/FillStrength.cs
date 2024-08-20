using UnityEngine;
using UnityEngine.EventSystems;

namespace snookerking.Core
{
    public class FillStrength : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public Strength strength;
        public void OnPointerDown(PointerEventData eventData)
        {
            strength.strength = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            strength.strength = false;
        }
    }
}