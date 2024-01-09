using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int currentHealth;
    private int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;
    private PlayerLifeState playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerLifeState>();    
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerHealth.currentHealth;
        maxHealth = playerHealth.maxHealth;
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
