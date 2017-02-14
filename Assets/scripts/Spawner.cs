using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float interval;
    public float prefabLivetime;

	void Start ()
    {
        StartCoroutine("spawn");
	}

    IEnumerator spawn()
    {
        while(true)
        {
            GameObject newObject = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(newObject, prefabLivetime);

            yield return new WaitForSeconds(interval);
        }
    }
}
