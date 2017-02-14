using UnityEngine;
using System.Collections;

public class AutoPosition : MonoBehaviour
{
    #if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Vector3 position = transform.localPosition;
        position.x = (int)position.x;
        position.y = (int)position.y;

        if (position.z < -1f)
        {
            position.z = -2f;
        }
        else if (position.z < 0f)
        {
            position.z = -1f;
        }
        else
        {
            position.z = 0f;
        }

        transform.localPosition = position;
    }
    #endif
}
