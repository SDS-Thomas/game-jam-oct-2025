using UnityEngine;
// https://docs.unity3d.com/ScriptReference/Camera.html
public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
     transform.position = new Vector3(
        player.transform.position.x + offset.x, 
        player.transform.position.y + offset.y,
        offset.z)
    ; // Camera follows the player with specified offset position
    }
}
