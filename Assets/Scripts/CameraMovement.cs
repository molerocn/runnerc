using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(player.transform.position.x);
        if (player.transform.position.x > 0)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
    }
}
