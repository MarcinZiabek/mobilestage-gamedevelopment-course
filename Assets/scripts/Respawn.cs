using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour 
{
    public GameObject ballPrefab;
    public Camera cameraPrefab;

    public Light lightPrefab;
    public GameObject gameOverTerrain;
    public GameObject levelName;

    public float lightingPower = 0.5f;

    void Start () 
    {
        GameObject ball = GameObject.Instantiate(ballPrefab);
        ball.transform.position = transform.position;
        ball.name = "ball";

        Camera camera = GameObject.Instantiate(cameraPrefab);

        CameraController cameraController = camera.GetComponent<CameraController>();
        cameraController.target = ball.transform;

        Light light = GameObject.Instantiate(lightPrefab).GetComponent<Light>();
        GameObject.Instantiate(gameOverTerrain);
        GameObject.Instantiate(levelName, transform.position + Vector3.forward*3f, Quaternion.identity);

        light.color = Color.white;
        light.intensity = 0.5f;
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = Color.white * 0.7f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("The little big ball");
        }
    }
}
