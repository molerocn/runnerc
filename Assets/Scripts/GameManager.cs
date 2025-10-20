using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    // metodo usado desde el script de player
    public void OnPlayerDeath()
    {
        Debug.Log("end end end");
        Time.timeScale = 0f;
    }
}
