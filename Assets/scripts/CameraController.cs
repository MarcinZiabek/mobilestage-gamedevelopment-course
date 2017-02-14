using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform target;
	
	void Start () 
	{
        transform.position = target.position;
	}

	void Update () 
	{
        Vector3 position = target.position;
        Rigidbody rigidbody = target.GetComponent<Rigidbody> ();
		float velocity = rigidbody.velocity.sqrMagnitude;

		float distance = velocity / 25f;

		if (distance > 1f) 
		{
			distance = 1f;
		}

		position += new Vector3(0f, 2f, -5f)*(1f+distance);
		transform.position = Vector3.Lerp(transform.position, position, Time.smoothDeltaTime);

        transform.LookAt (target);
	}
}
