using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsGameOver { get; private set; }

    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;

    private int score = 0;

    // Start is called before the first frame update
    private void Awake() // 객체가 생성되지마자 호출됨
    {
        if (Instance == null)
        {
            Instance = this;
            gameOverText.SetActive(false);
        }
        else
        {
            Debug.LogWarning("GameManager instance already exists, destroying this one.");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(IsGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 현재 열려 있는 씬을 다시 로드하라
        }
    }

    public void AddScore(int newScore)
    {
        if (IsGameOver)
            return;

        score += newScore;
        scoreText.text = $"SCORE : {score}";
    }

    public void OnPlayerDead()
    {
        IsGameOver = true;
        gameOverText.SetActive(true);
    }
}
