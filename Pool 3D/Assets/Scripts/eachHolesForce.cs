using UnityEngine;

public class eachHolesForce : MonoBehaviour
{
	private Vector3 thisPosition;

	private int thisTriggerNumber;

	private Rigidbody targetRigidbody;

	private void Start()
	{
		thisPosition = base.transform.position;
		thisTriggerNumber = int.Parse(base.gameObject.name.Replace("Capsule", string.Empty));
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (!collision.GetComponent<Collider>().CompareTag("ballTag") && !(collision.GetComponent<Collider>().name == "cueBall"))
		{
			return;
		}
		targetRigidbody = collision.GetComponent<Rigidbody>();
		targetRigidbody.constraints &= (RigidbodyConstraints)(-5);
		Vector3 a = thisPosition;
		a.y = mainScript.CUEBALL_START_POS.y;
		if (thisTriggerNumber == 1 || thisTriggerNumber == 4)
		{
			if (targetRigidbody.velocity.magnitude < 6f)
			{
				targetRigidbody.AddForce((a - targetRigidbody.position).normalized * Mathf.Clamp(targetRigidbody.velocity.magnitude, 2.5f, 3.1f), ForceMode.Impulse);
			}
			else
			{
				targetRigidbody.velocity = (a - targetRigidbody.position).normalized * targetRigidbody.velocity.magnitude;
			}
		}
		else if (targetRigidbody.velocity.magnitude < 6f)
		{
			targetRigidbody.AddForce((a - targetRigidbody.position).normalized * Mathf.Clamp(targetRigidbody.velocity.magnitude, 2.5f, 3.1f), ForceMode.Impulse);
		}
	}
}
