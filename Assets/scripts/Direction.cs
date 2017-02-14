using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour
{
    void OnTriggerStay(Collider collision)
    {
        GameObject thing = collision.gameObject;
        Rigidbody rigidbody = thing.GetComponent<Rigidbody>();
        Vector3 velocity = rigidbody.velocity;

        float delta = 0.25f;

        if(transform.rotation.y == 0)
        {
            if (velocity.x < delta)
            {
                velocity.x = delta;
            }
        }
        else
        {
            if (velocity.x > -delta)
            {
                velocity.x = -delta;
            }
        }

        rigidbody.velocity = velocity;
    }
}
