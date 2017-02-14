using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	void Start () 
	{
		if (Application.platform == RuntimePlatform.Android) 
		{
			this.enabled = false;
		}
	}

	void Update () 
	{
        updateControlls();
        updatePosition();
        updateLayer();
	}

    void updateControlls()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.forward;
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.back;
        } 
        else
        {
            direction = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            bool isSomething = Physics.Raycast(transform.position, Vector3.forward, 2f);
            Debug.DrawRay(transform.position, Vector3.forward * 2f);

            if (!isSomething)
            {
                layer = 0;
            }
        } 
        else if (Input.GetKey(KeyCode.DownArrow)) 
        {
            bool isSomething = Physics.Raycast(transform.position, Vector3.back, 2f);
            Debug.DrawRay(transform.position, Vector3.back*2f);

            if (!isSomething)
            {
                layer = 1;
            }
        } 
    }

    Vector3 direction = Vector3.zero;
    public float torqueFactor = 50f;

    void updatePosition()
    {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = 10f;
        rigidbody.AddTorque(direction*torqueFactor, ForceMode.Force);
    }

    int layer = 0;
    float layerSize = 2f;
    float layerChangeSpeed = 3f;

    void updateLayer()
    {
        float delta = GetComponent<Rigidbody>().position.z + layerSize * layer;
        
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        velocity.z = -delta*layerChangeSpeed;
        GetComponent<Rigidbody>().velocity = velocity;
    }
}
