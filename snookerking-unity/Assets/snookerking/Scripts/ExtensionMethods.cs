using UnityEngine;

public static class ExtensionMethods
{
	public static void SetPositionX(this Transform transform, float x)
	{
		Vector3 position = transform.position;
		float y = position.y;
		Vector3 position2 = transform.position;
		transform.position = new Vector3(x, y, position2.z);
	}

	public static void SetPositionY(this Transform transform, float y)
	{
		Vector3 position = transform.position;
		float x = position.x;
		Vector3 position2 = transform.position;
		transform.position = new Vector3(x, y, position2.z);
	}

	public static void SetPositionZ(this Transform transform, float z)
	{
		Vector3 position = transform.position;
		float x = position.x;
		Vector3 position2 = transform.position;
		transform.position = new Vector3(x, position2.y, z);
	}

	public static void AddPosition(this Transform transform, Vector3 offset)
	{
		transform.position += offset;
	}

	public static void AddPosition(this Transform transform, float x, float y, float z)
	{
		transform.position += new Vector3(x, y, z);
	}

	public static void SetLocalPositionX(this Transform transform, float x)
	{
		Vector3 localPosition = transform.localPosition;
		float y = localPosition.y;
		Vector3 localPosition2 = transform.localPosition;
		transform.localPosition = new Vector3(x, y, localPosition2.z);
	}

	public static void SetLocalPositionY(this Transform transform, float y)
	{
		Vector3 localPosition = transform.localPosition;
		float x = localPosition.x;
		Vector3 localPosition2 = transform.localPosition;
		transform.localPosition = new Vector3(x, y, localPosition2.z);
	}

	public static void SetLocalPositionZ(this Transform transform, float z)
	{
		Vector3 localPosition = transform.localPosition;
		float x = localPosition.x;
		Vector3 localPosition2 = transform.localPosition;
		transform.localPosition = new Vector3(x, localPosition2.y, z);
	}

	public static void SetEulerAnglesX(this Transform transform, float x)
	{
		Vector3 eulerAngles = transform.eulerAngles;
		float y = eulerAngles.y;
		Vector3 eulerAngles2 = transform.eulerAngles;
		transform.eulerAngles = new Vector3(x, y, eulerAngles2.z);
	}

	public static void SetEulerAnglesY(this Transform transform, float y)
	{
		Vector3 eulerAngles = transform.eulerAngles;
		float x = eulerAngles.x;
		Vector3 eulerAngles2 = transform.eulerAngles;
		transform.eulerAngles = new Vector3(x, y, eulerAngles2.z);
	}

	public static void SetEulerAnglesZ(this Transform transform, float z)
	{
		Vector3 eulerAngles = transform.eulerAngles;
		float x = eulerAngles.x;
		Vector3 eulerAngles2 = transform.eulerAngles;
		transform.eulerAngles = new Vector3(x, eulerAngles2.y, z);
	}

	public static void SetLocalEulerAnglesX(this Transform transform, float x)
	{
		Vector3 localEulerAngles = transform.localEulerAngles;
		float y = localEulerAngles.y;
		Vector3 localEulerAngles2 = transform.localEulerAngles;
		transform.localEulerAngles = new Vector3(x, y, localEulerAngles2.z);
	}

	public static void SetLocalEulerAnglesY(this Transform transform, float y)
	{
		Vector3 localEulerAngles = transform.localEulerAngles;
		float x = localEulerAngles.x;
		Vector3 localEulerAngles2 = transform.localEulerAngles;
		transform.localEulerAngles = new Vector3(x, y, localEulerAngles2.z);
	}

	public static void SetLocalEulerAnglesZ(this Transform transform, float z)
	{
		Vector3 localEulerAngles = transform.localEulerAngles;
		float x = localEulerAngles.x;
		Vector3 localEulerAngles2 = transform.localEulerAngles;
		transform.localEulerAngles = new Vector3(x, localEulerAngles2.y, z);
	}

	public static void SetRotationX(this Transform transform, float x)
	{
		Quaternion rotation = transform.rotation;
		Quaternion rotation2 = transform.rotation;
		float y = rotation2.y;
		Quaternion rotation3 = transform.rotation;
		transform.rotation = rotation * Quaternion.Euler(x, y, rotation3.z);
	}

	public static void SetRotationY(this Transform transform, float y)
	{
		Quaternion rotation = transform.rotation;
		Quaternion rotation2 = transform.rotation;
		float x = rotation2.x;
		Quaternion rotation3 = transform.rotation;
		transform.rotation = rotation * Quaternion.Euler(x, y, rotation3.z);
	}

	public static void SetRotationZ(this Transform transform, float z)
	{
		Quaternion rotation = transform.rotation;
		Quaternion rotation2 = transform.rotation;
		float x = rotation2.x;
		Quaternion rotation3 = transform.rotation;
		transform.rotation = rotation * Quaternion.Euler(x, rotation3.y, z);
	}

	public static void AddRotation(this Transform transform, Vector3 offset)
	{
		transform.rotation *= Quaternion.Euler(offset);
	}

	public static void AddRotation(this Transform transform, float x, float y, float z)
	{
		transform.rotation *= Quaternion.Euler(new Vector3(x, y, z));
	}

	public static void SetScaleX(this Transform transform, float x)
	{
		Vector3 localScale = transform.localScale;
		float y = localScale.y;
		Vector3 localScale2 = transform.localScale;
		transform.localScale = new Vector3(x, y, localScale2.z);
	}

	public static void SetScaleY(this Transform transform, float y)
	{
		Vector3 localScale = transform.localScale;
		float x = localScale.x;
		Vector3 localScale2 = transform.localScale;
		transform.localScale = new Vector3(x, y, localScale2.z);
	}

	public static void SetScaleZ(this Transform transform, float z)
	{
		Vector3 localScale = transform.localScale;
		float x = localScale.x;
		Vector3 localScale2 = transform.localScale;
		transform.localScale = new Vector3(x, localScale2.y, z);
	}

	public static void AddScale(this Transform transform, Vector3 offset)
	{
		transform.localScale += offset;
	}

	public static void AddScale(this Transform transform, float x, float y, float z)
	{
		transform.localScale += new Vector3(x, y, z);
	}

	public static void SetPositionX(this Rigidbody rigidbody, float x)
	{
		Vector3 position = rigidbody.position;
		float y = position.y;
		Vector3 position2 = rigidbody.position;
		rigidbody.position = new Vector3(x, y, position2.z);
	}

	public static void SetPositionY(this Rigidbody rigidbody, float y)
	{
		Vector3 position = rigidbody.position;
		float x = position.x;
		Vector3 position2 = rigidbody.position;
		rigidbody.position = new Vector3(x, y, position2.z);
	}

	public static void SetPositionZ(this Rigidbody rigidbody, float z)
	{
		Vector3 position = rigidbody.position;
		float x = position.x;
		Vector3 position2 = rigidbody.position;
		rigidbody.position = new Vector3(x, position2.y, z);
	}

	public static void SetAnchoredPositionX(this RectTransform transform, float x)
	{
		Vector2 anchoredPosition = transform.anchoredPosition;
		transform.anchoredPosition = new Vector2(x, anchoredPosition.y);
	}

	public static void SetAnchoredPositionY(this RectTransform transform, float y)
	{
		Vector2 anchoredPosition = transform.anchoredPosition;
		transform.anchoredPosition = new Vector2(anchoredPosition.x, y);
	}

	public static void SetSizeDeltaX(this RectTransform transform, float x)
	{
		Vector2 sizeDelta = transform.sizeDelta;
		transform.sizeDelta = new Vector2(x, sizeDelta.y);
	}

	public static void SetSizeDeltaY(this RectTransform transform, float y)
	{
		Vector2 sizeDelta = transform.sizeDelta;
		transform.sizeDelta = new Vector2(sizeDelta.x, y);
	}
}
