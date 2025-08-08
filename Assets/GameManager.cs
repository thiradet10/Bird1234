using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreTextUi;
    public Text gameOverTextUi;
    public Button playButton;
    public PipCreatorscript pipCreator;

    private static bool isRestarting = false;

    public float pipeSpeed = 5f;
    private float initialPipeSpeed = 5f;
    public float speedIncreaseAmount = 0.2f;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameOverTextUi.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);

        if (isRestarting)
        {
            
            Time.timeScale = 1f;
            isRestarting = false;
        }
        else
        {
            
            Debug.Log("Game Started");
            Pause();
        }

        scoreTextUi.text = score.ToString();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        playButton.gameObject.SetActive(true);
    }

    public void Play()
    {
        
        isRestarting = true;

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScore()
    {
        score++; 
        scoreTextUi.text = score.ToString();

        pipeSpeed += speedIncreaseAmount;
        Debug.Log("Score: " + score + ", New Pipe Speed: " + pipeSpeed);

        if (score % 5 == 0 && pipCreator.spawnTime > 0.8f)
        {
            pipCreator.spawnTime -= 0.3f;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        
        gameOverTextUi.gameObject.SetActive(true);
        Pause();
    }
}