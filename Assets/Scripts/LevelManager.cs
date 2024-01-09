using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{   
    public void StartGame()
    {
        SceneManager.LoadScene("Level Menu Screen");
        AudioManager.instance.PlayEffectSound("Select");
    }

    public void QuitGame()
    {
        AudioManager.instance.PlayEffectSound("Select");
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Game Theme");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Game Theme");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Game Theme");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level 4");
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Game Theme");
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level 5");
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Game Theme");
    }

    public void Level6()
    {
        SceneManager.LoadScene("Level 6");
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Game Theme");
    }

    public void BackToMainScreen()
    {
        SceneManager.LoadScene("Main Page Screen");
        AudioManager.instance.PlayEffectSound("Select");
    }
}
