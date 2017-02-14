using UnityEngine;
using System.Collections;

public class LevelName : MonoBehaviour 
{
	void Start () 
    {
        TextMesh text = transform.GetComponent<TextMesh>();
        text.text = Application.loadedLevelName;
	}
}
