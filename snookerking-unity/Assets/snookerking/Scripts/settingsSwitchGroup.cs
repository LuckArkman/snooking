using UnityEngine;

public class settingsSwitchGroup : MonoBehaviour
{
	private RectTransform groupRectTrans1;

	private RectTransform groupRectTrans2;

	private GameObject leftArrowObj;

	private GameObject rightArrowObj;

	private float animValue;

	private float animVel;

	private float animTarget;

	private void Awake()
	{
		groupRectTrans1 = base.transform.Find("Group1").gameObject.GetComponent<RectTransform>();
		groupRectTrans2 = base.transform.Find("Group2").gameObject.GetComponent<RectTransform>();
		leftArrowObj = base.transform.Find("ArrowLeft").gameObject;
		rightArrowObj = base.transform.Find("ArrowRight").gameObject;
		leftArrowObj.SetActive(value: false);
		RectTransform rectTransform = groupRectTrans2;
		Vector2 anchoredPosition = groupRectTrans2.anchoredPosition;
		rectTransform.anchoredPosition = new Vector2(1000f, anchoredPosition.y);
	}

	private void Update()
	{
		animValue = Mathf.SmoothDamp(animValue, animTarget, ref animVel, 0.15f, float.PositiveInfinity, mainScript.deltaTimeCustom);
		RectTransform rectTransform = groupRectTrans1;
		float x = animValue * -1000f;
		Vector2 anchoredPosition = groupRectTrans1.anchoredPosition;
		rectTransform.anchoredPosition = new Vector2(x, anchoredPosition.y);
		RectTransform rectTransform2 = groupRectTrans2;
		float x2 = (1f - animValue) * 1000f;
		Vector2 anchoredPosition2 = groupRectTrans2.anchoredPosition;
		rectTransform2.anchoredPosition = new Vector2(x2, anchoredPosition2.y);
	}

	private void showGroup1()
	{
		animTarget = 0f;
		leftArrowObj.SetActive(value: false);
		rightArrowObj.SetActive(value: true);
	}

	private void showGroup2()
	{
		animTarget = 1f;
		leftArrowObj.SetActive(value: true);
		rightArrowObj.SetActive(value: false);
	}
}
