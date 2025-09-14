using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public enum Scene
    {
        forest,
        cave,
        underwater
    }

    public Scene scene = Scene.forest;

    void Start() { }

    void Update() { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (scene)
            {
                case Scene.forest:
                    SceneManager.LoadScene("ForestScene");
                    break;
                case Scene.cave:
                    SceneManager.LoadScene("CaveScene");
                    break;
                case Scene.underwater:
                    SceneManager.LoadScene("UnderWaterScene");
                    break;
                default: break;
            }
        }
    }
}
