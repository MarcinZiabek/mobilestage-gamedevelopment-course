using UnityEngine;
using System.Collections;

public class GameOverTrigger : MonoBehaviour 
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "ball")
        {
            string levelName = Application.loadedLevelName;
            Application.LoadLevel(levelName);
        }
    }
}
