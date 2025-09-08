using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject startPoint;
    public GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = startPoint.transform.position;
        }
    }
}
