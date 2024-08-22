using UnityEngine;

public class uiAnimatorPowerMeter : MonoBehaviour
{
	private RectTransform rectTransform;

	private CanvasGroup thisCanvasGroup;

	public static float targetPosX;

	private float animValue = 1f;

	private float animVel;

	public static float animTarget = 1f;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		thisCanvasGroup = GetComponent<CanvasGroup>();
		Vector2 anchoredPosition = rectTransform.anchoredPosition;
		targetPosX = anchoredPosition.x;
		RectTransform obj = rectTransform;
		float x = targetPosX - animValue * targetPosX;
		Vector2 anchoredPosition2 = rectTransform.anchoredPosition;
		obj.anchoredPosition = new Vector2(x, anchoredPosition2.y);
		thisCanvasGroup.alpha = 1f - animValue;
	}

	private void Update()
	{
		animValue = Mathf.SmoothDamp(animValue, animTarget, ref animVel, 0.15f, float.PositiveInfinity, mainScript.deltaTimeCustom);
		RectTransform obj = rectTransform;
		float x = targetPosX - animValue * (targetPosX * 1.1f);
		Vector2 anchoredPosition = rectTransform.anchoredPosition;
		obj.anchoredPosition = new Vector2(x, anchoredPosition.y);
		thisCanvasGroup.alpha = 1f - animValue;
	}
}
