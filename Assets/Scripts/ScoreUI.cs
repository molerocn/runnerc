using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore(GameManager.Instance.score);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(GameManager.Instance.score);
    }

    private void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
