using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace snookerking.Core
{
    public class AimBall : MonoBehaviour
    {
        public Image sprite;
        public Vector2 centro;
        public float circ;
        public GameObject obj;

        private void Update()
        {
            OnCenter();
        }

        [ContextMenu(nameof(OnCenter))]
        void OnCenter()
        {
            centro = new Vector2(sprite.rectTransform.rect.width / 2, sprite.rectTransform.rect.height / 2);
            circ = 2 * Mathf.PI * (sprite.rectTransform.rect.width / 2);
            /*
            float distancia = Vector2.Distance(sprite.rectTransform.rect.position + new Vector2(sprite.rectTransform.rect.width / 2, sprite.rectTransform.rect.height / 2),obj.transform.localPosition);
            float raio = sprite.rectTransform.rect.width / 2;
            if (distancia > raio)
            {
                Debug.Log("O objeto saiu de dentro da circunferência!");
            }
            else
            {
                Debug.Log("O objeto está dentro da circunferência.");
            }
            */
        }

        public void InArea(RectTransform rectTransform)
        {
            float distancia = Vector2.Distance(sprite.rectTransform.rect.position + new Vector2(sprite.rectTransform.rect.width / 2, sprite.rectTransform.rect.height / 2),rectTransform.transform.localPosition);
            float raio = sprite.rectTransform.rect.width / 2;
            if (distancia > raio)
            {
                Debug.Log("O objeto saiu de dentro da circunferência!");
            }
            else
            {
                Debug.Log("O objeto está dentro da circunferência.");
            }
        }
    }
}