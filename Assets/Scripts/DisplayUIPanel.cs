using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUIPanel : MonoBehaviour
{
    [SerializeField] GameObject UI;
    private bool isOpen = false;

    public void OpenAndClosePanel()
    {
        isOpen = !isOpen;
        UI.SetActive(isOpen);
        AudioManager.instance.PlayEffectSound("Select");
    }
}
