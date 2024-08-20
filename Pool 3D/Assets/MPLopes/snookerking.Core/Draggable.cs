using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace snookerking.Core
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Image draggableImage; // Campo público para a imagem que será arrastada
        public AimBall _aimBall;

        public RectTransform rectTransform;
        public CanvasGroup canvasGroup;

        private void Awake()
        {
            rectTransform = draggableImage.GetComponent<RectTransform>();
            canvasGroup = draggableImage.GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
            _aimBall.InArea(rectTransform);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f; // Tornar a imagem opaca novamente
            canvasGroup.blocksRaycasts = true; // Ativar o bloqueio de raycast
        }
    }
}