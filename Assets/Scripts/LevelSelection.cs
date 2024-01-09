using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButton;
    public GameObject[] levelBadges;

    // Start is called before the first frame update
    void Start()
    {
        int levelSaved = PlayerPrefs.GetInt("LevelSaved", 2);
        for (int i = 0; i < levelButton.Length; i++) 
        {
            if(i + 2 > levelSaved) 
            {
                levelButton[i].interactable = false;
            }
            // Set badge active if the level is completed
            levelBadges[i].SetActive(i + 2 < levelSaved);
        }
    }
}
