using UnityEngine;

public class settingsArrowAnim : MonoBehaviour
{
	private RectTransform rectTransform;

	public bool isRight;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	private void Update()
	{
		Vector3 v = rectTransform.anchoredPosition;
		if (isRight)
		{
			v.x = Mathf.PingPong(Time.realtimeSinceStartup * 30f, 10f);
			rectTransform.anchoredPosition = v;
		}
		else
		{
			v.x = 50f - Mathf.PingPong(Time.realtimeSinceStartup * 30f, 10f);
			rectTransform.anchoredPosition = v;
		}
	}
}
