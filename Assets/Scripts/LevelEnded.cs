using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnded : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    private TimeCountdown time;
    private PlayerLifeState life;

    [SerializeField] GameObject winUI;
    private BoxGoalNumber isLevelCompleted;
    private int recordLevelProgress;

    // Start is called before the first frame update
    void Start()
    {
        time = GetComponent<TimeCountdown>();
        life = GetComponent<PlayerLifeState>();
        isLevelCompleted = GetComponent<BoxGoalNumber>();
        recordLevelProgress = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        GameOverUI();
        WinUI();
    }

    public void GameOverUI()
    {
        if (time.remainingTime == 0 || life.currentHealth == 0)
        {
            StartCoroutine(DelayGameOver(1.5f));
        }
    }

    IEnumerator DelayGameOver(float time)
    {
        yield return new WaitForSeconds(time);
        gameOverUI.SetActive(true);
    }

    public void WinUI()
    {
        if (isLevelCompleted.isCompleted)
        {
            StartCoroutine(DelayWin(1.3f));
        }
    }

    IEnumerator DelayWin(float time)
    {
        yield return new WaitForSeconds(time);
        winUI.SetActive(true);

        //Record new level progress
        if (recordLevelProgress > PlayerPrefs.GetInt("LevelSaved"))
        {
            PlayerPrefs.SetInt("LevelSaved", recordLevelProgress);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(recordLevelProgress);
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Game Theme");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Game Theme");
    }

    public void LevelMenuPage()
    {
        SceneManager.LoadScene("Level Menu Screen");
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Main Menu Theme");
    }
}
