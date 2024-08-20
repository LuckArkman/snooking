using UnityEngine;

public class rotateBall : MonoBehaviour
{
	private Transform thisTransform;

	private Rigidbody thisRigidbody;

	private Transform innerMeshTransform;

	private mainScript mainScriptComp;

	private void Start()
	{
		thisTransform = base.transform;
		thisRigidbody = GetComponent<Rigidbody>();
		innerMeshTransform = thisTransform.Find("ballMesh");
		mainScriptComp = GameObject.Find("cueBall").GetComponent<mainScript>();
		innerMeshTransform.eulerAngles = new Vector3(UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f));
	}

	private void FixedUpdate()
	{
		if (thisRigidbody.isKinematic)
		{
			return;
		}
		if (thisRigidbody.velocity.magnitude > 4f)
		{
			thisRigidbody.velocity *= 0.993f;
		}
		else if (thisRigidbody.velocity.magnitude > 2f)
		{
			thisRigidbody.velocity *= 0.99f;
		}
		else if (thisRigidbody.velocity.magnitude > 0f)
		{
			thisRigidbody.velocity *= 0.96f;
			if (thisRigidbody.velocity.magnitude < 0.1f)
			{
				thisRigidbody.velocity = Vector3.zero;
			}
		}
		if (thisRigidbody.velocity.magnitude > 0.1f)
		{
			Transform transform = innerMeshTransform;
			Vector3 velocity = thisRigidbody.velocity;
			float xAngle = velocity.z * 2f;
			Vector3 velocity2 = thisRigidbody.velocity;
			transform.Rotate(xAngle, 0f, (0f - velocity2.x) * 2f, Space.World);
		}
		thisRigidbody.AddForce(0f, -60f, 0f, ForceMode.Force);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (thisRigidbody.velocity.magnitude > 0.05f && collision.collider.CompareTag("ballTag") && Vector3.Angle(thisRigidbody.velocity, collision.contacts[0].normal) < 84f && collision.contacts[0].thisCollider.GetComponent<Rigidbody>().velocity.magnitude > collision.contacts[0].otherCollider.GetComponent<Rigidbody>().velocity.magnitude)
		{
			mainScriptComp.playBallHitSound(Mathf.Clamp(thisRigidbody.velocity.magnitude / 30f, 0.04f, 1f));
		}
		if (collision.collider.CompareTag("colSideTag") || collision.collider.CompareTag("colSideEndTag") || collision.collider.CompareTag("colHoleTag"))
		{
			if (mainScript.railHitBallArray[int.Parse(base.gameObject.name) - 1] != 1)
			{
				mainScript.railHitCountInThisShot++;
				mainScript.railHitBallArray[int.Parse(base.gameObject.name) - 1] = 1;
			}
			if (Vector3.Angle(thisRigidbody.velocity, collision.contacts[0].normal) < 80f)
			{
				mainScriptComp.playRailHitSound(thisTransform.position, Mathf.Clamp(thisRigidbody.velocity.magnitude / 45f, 0.06f, 1f));
			}
		}
	}
}
