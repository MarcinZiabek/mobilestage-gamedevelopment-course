using UnityEngine;
using System.Collections;

public class LevelItem : MonoBehaviour
{
    public string levelName;
    public TextMesh text;
    public GameObject okey;

    void Start()
    {
        if(PlayerPrefs.GetInt(levelName+"_finished")==0)
        {
            Destroy(okey);
        }

        text.text = levelName;
    }

    void OnMouseDown()
    {
        Application.LoadLevel(levelName);
    }
}
