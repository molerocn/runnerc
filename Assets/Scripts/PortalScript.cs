using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public enum Scene
    {
        main,
        under,
        heaven
    }
    public Scene scene = Scene.main;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            switch (scene)
            {
                case Scene.main:
                    SceneManager.LoadScene("MainScene");
                    break;
                case Scene.under:
                    SceneManager.LoadScene("UnderScene");
                    break;
                case Scene.heaven:
                    SceneManager.LoadScene("HeavenScene");
                    break;
                default: break;
            }
        }
    }
}
