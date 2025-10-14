using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = transform.position;
        }
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        if (mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(player.transform.position.x + 4, mainCamera.transform.position.y, -10);
        }
    }

}
