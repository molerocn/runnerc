using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isDead = false;
    public static Player Instance;
    
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


    public void Die()
    {
        if (isDead) return;
        isDead = true;
    
        Debug.Log("muriendo..");
        GameManager.Instance.OnPlayerDeath();
    }
}
