using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
    bool active = false;
    Vector3 plateStartPosition;

    public Transform plate;
    public Rigidbody door;
    Vector3 doorStartPosition;

    void Start ()
    {
        plateStartPosition = plate.position;
        doorStartPosition = door.position;
    }

	void Update ()
    {
        Vector3 plateNewPosition;
        Vector3 doorNewPosition;

        if (active)
        {
            plateNewPosition = plateStartPosition - Vector3.up * 0.15f;
            doorNewPosition = doorStartPosition + Vector3.up * 2.5f;
        }
        else
        {
            plateNewPosition = plateStartPosition;
            doorNewPosition = doorStartPosition;
        }

        plate.position = Vector3.Lerp(plate.position, plateNewPosition, Time.deltaTime * 4f);
        door.position = Vector3.Lerp(door.position, doorNewPosition, Time.deltaTime * 4f);
    }

    void FixedUpdate()
    {
        active = false;
    }

    void OnTriggerStay(Collider collider)
    {
        active = true;
    }

    #if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if(!door)
        {
            return;
        }

        Gizmos.color = Color.yellow;

        Vector3 ghostSize = door.rotation * door.transform.localScale * 2f;
        Gizmos.DrawWireCube(door.position, ghostSize);
    }
    #endif
}
