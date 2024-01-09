using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackgroundMusicIconButton : MonoBehaviour
{
    public Sprite muteIcon;
    public Sprite notMuteIcon;
    public Button button;

    private void Awake()
    {
        UpdateButtonIcon();
    }

    void Update()
    {
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        bool isBackgroundMusicMuted = AudioManager.instance.backgroundMusicSource.mute;
        button.image.sprite = isBackgroundMusicMuted ? muteIcon : notMuteIcon;
    }
}
