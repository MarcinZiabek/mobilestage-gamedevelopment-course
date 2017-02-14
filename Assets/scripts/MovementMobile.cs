using UnityEngine;
using System.Collections;

public class MovementMobile : MonoBehaviour 
{
	void Start () 
    {
        if (Application.platform != RuntimePlatform.Android) 
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

    Vector3 touchStart;
    Vector3 touchDelta;

    void updateControlls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        } 

        if (Input.GetMouseButton(0))
        {
            touchDelta = Input.mousePosition - touchStart;
            touchDelta /= Screen.dpi;
        } 
        else
        {
            touchDelta = Vector3.zero;
        }

        direction = new Vector3(0, 0, -touchDelta.x);

        if(touchDelta.y > 0.5f)
        {
            bool isSomething = Physics.Raycast(transform.position, Vector3.forward, 4f);

            if (!isSomething)
            {
                layer = 0;
            }
        }
        
        if(touchDelta.y < -0.5f)
        {
            bool isSomething = Physics.Raycast(transform.position, Vector3.back, 4f);

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
        rigidbody.AddTorque(direction*torqueFactor);
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
