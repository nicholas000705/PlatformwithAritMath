using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuPanel : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    public Slider backgroundMusicSlider, effectSoundSlider;
    private float currentBackgroundMusicVolume, currentEffectSoundVolume;

    private void Awake()
    {
        currentBackgroundMusicVolume = AudioManager.instance.backgroundMusicSource.volume;
        backgroundMusicSlider.value = currentBackgroundMusicVolume;

        currentEffectSoundVolume = AudioManager.instance.effectMusicSource.volume;
        effectSoundSlider.value = currentEffectSoundVolume;
    }

    public void GameMainMenu()
    {
        mainMenuUI.SetActive(true);
        AudioManager.instance.PlayEffectSound("Select");
    }

    public void Resume()
    {
        mainMenuUI.SetActive(false);
        AudioManager.instance.PlayEffectSound("Back/Resume");
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Game Theme");
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Level Menu Screen");
        AudioManager.instance.PlayEffectSound("Select");
        AudioManager.instance.PlayBackgroundMusic("Main Menu Theme");
    }

    public void ToggleBackgroundMusic()
    {
        AudioManager.instance.ToggleBackgroundMusic();
    }
    
    public void ToggleEffectSound() 
    {
        AudioManager.instance.ToggleEffectSound();
    }

    public void BackgroundMusicVolume()
    {
        AudioManager.instance.BackgroundMusicSettings(backgroundMusicSlider.value);
    }

    public void EffectSoundVolume() 
    {
        AudioManager.instance.EffectSoundVolumeSettings(effectSoundSlider.value);
    }
}
