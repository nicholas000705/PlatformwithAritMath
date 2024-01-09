using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEffectMusicIconButton : MonoBehaviour
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
        bool isEffectMusicMuted = AudioManager.instance.effectMusicSource.mute;
        button.image.sprite = isEffectMusicMuted ? muteIcon : notMuteIcon;
    }
}
