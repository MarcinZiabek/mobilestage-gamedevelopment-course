using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{
	IEnumerator Start ()
    {
        yield return new WaitForSeconds(2.5f);
        Application.LoadLevel("The little big ball");
	}
}
