using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnItems;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private CanvasRenderer restartButton;

    [SerializeField] private bool gameIsOver;
    public int score;
    [SerializeField] float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        gameOverText = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        restartButton = GameObject.Find("Restart Button").GetComponent<CanvasRenderer>();

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        gameIsOver = false;
        score = 0;
        scoreText.text = $"Score : {score}";

        UpdateScore(0);


        StartCoroutine(SpawnTarget());
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score : {score}";
    }

    IEnumerator SpawnTarget()
    {
        while (!gameIsOver)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, spawnItems.Length);
            Instantiate(spawnItems[index]);
        }
    }

    public void GameOver()
    {
        gameIsOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
