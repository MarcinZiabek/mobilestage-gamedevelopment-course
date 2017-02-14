using UnityEngine;
using System.Collections;

public class CloseApp : MonoBehaviour
{
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
