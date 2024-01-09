using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCountdown : MonoBehaviour
{
    [SerializeField] private float totalTime;
    public float remainingTime;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI timeUsedText;
    private BoxGoalNumber goalNumber;

    void Start()
    {
        goalNumber = GetComponent<BoxGoalNumber>();
        remainingTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!goalNumber.isCompleted)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                remainingTime = 0;
            }
        }
        DisplayTime(remainingTime);
        UsedTime(remainingTime, totalTime);
    }

    void DisplayTime(float timeLeft)
    {
        if(timeLeft < 0)
        {
            timeLeft = 0;
        }

        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UsedTime(float timeLeft, float totalTime)
    {
        float timeUsed = totalTime - timeLeft;
        float minutes = Mathf.FloorToInt(timeUsed / 60);
        float seconds = Mathf.FloorToInt(timeUsed % 60);

        timeUsedText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
