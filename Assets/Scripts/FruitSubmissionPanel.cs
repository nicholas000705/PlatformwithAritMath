using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class FruitSubmissionPanel : MonoBehaviour
{
    private enum Inequality { Equals, Less_Than, More_Than, Less_Than_Equal, More_Than_Equal };

    [Header("General Settings")]
    [SerializeField] GameObject globalFruit;
    [SerializeField] GameObject submissionUI;
    [SerializeField] private GameObject correctMark;
    [SerializeField] private GameObject wrongMark;
    [SerializeField] private TextMeshProUGUI appleNumberText;
    [SerializeField] private TextMeshProUGUI bananaNumberText;
    public int appleInBox;
    public int bananaInBox;
    private Transform player;
    private bool isAchieved = false;
    private bool isAllCorrect = false;
    private GlobalFruitNumber fruit;


    [Header("Target Score")]
    [SerializeField] private int scoreApple = 5;
    [SerializeField] private int scoreBanana = 10;
    [SerializeField] private Inequality targetTypeScore;
    [SerializeField] private int scoreTarget;


    [Header("Target Apple Number")]
    [SerializeField] private Inequality targetNumberApple;
    [SerializeField] private int numberTargetApple;


    [Header("Target Banana Number")]
    [SerializeField] private Inequality targetNumberBanana;
    [SerializeField] private int numberTargetBanana;

    private bool isScoreCondition = false;
    private bool isNumberAppleCondition = false;
    private bool isNumberBananaCondition = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fruit = globalFruit.GetComponent<GlobalFruitNumber>();
    }

    void Update()
    {
        appleNumberText.text = appleInBox.ToString();
        bananaNumberText.text = bananaInBox.ToString();

        if (player != null && Vector2.Distance(transform.position, player.position) < 2f)
        {
            submissionUI.SetActive(true);
        }
        else
        {
            submissionUI.SetActive(false);
        }

        isScoreCondition = IsScoreCorrect(targetTypeScore);
        isNumberAppleCondition = IsAppleCorrect(targetNumberApple);
        isNumberBananaCondition = IsBananaCorrect(targetNumberBanana);
        ScoreCalculate();
    }

    public void ScoreCalculate()
    {
        if (isScoreCondition && isNumberAppleCondition && isNumberBananaCondition)
        {
            isAllCorrect = true;
            correctMark.SetActive(true);
            wrongMark.SetActive(false);
        }
        else
        {
            isAllCorrect = false;
            correctMark.SetActive(false);
            wrongMark.SetActive(true);
        }
    }

    public int BoxCalculate()
    {
        if (isAchieved == false)
        {
            if (isAllCorrect)
            {
                isAchieved = true;
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else if (isAchieved == true)
        {
            if (!isAllCorrect)
            {
                isAchieved = false;
                return -1;
            }
            else
            {
                return 0;
            }
        }
        else
            return 0;
        
    }

    public void MinusSelectedApple()
    {
        if (appleInBox != 0)
        {
            appleInBox--;
            fruit.appleCount++;
        }
        AudioManager.instance.PlayEffectSound("Putting/Taking Fruit from Box");
    }

    public void MinusSelectedBanana()
    {
        if (bananaInBox != 0)
        {
            bananaInBox--;
            fruit.bananaCount++;
        }
        AudioManager.instance.PlayEffectSound("Putting/Taking Fruit from Box");
    }

    public void AddSelectedApple()
    {
        if (fruit.appleCount != 0)
        {
            appleInBox++;
            fruit.appleCount--;
        }
        AudioManager.instance.PlayEffectSound("Putting/Taking Fruit from Box");
    }

    public void AddSelectedBanana()
    {   
        if (fruit.bananaCount != 0)
        {
            bananaInBox++;
            fruit.bananaCount--;
        }
        AudioManager.instance.PlayEffectSound("Putting/Taking Fruit from Box");
    }

    private bool IsScoreCorrect(Inequality score)
    {
        if (score == Inequality.Equals)
        {
            return (appleInBox * scoreApple) + (bananaInBox * scoreBanana) == scoreTarget;
        }
        else if (score == Inequality.Less_Than)
        {
            return (appleInBox * scoreApple) + (bananaInBox * scoreBanana) < scoreTarget;
        }
        else if (score == Inequality.Less_Than_Equal)
        {
            return (appleInBox * scoreApple) + (bananaInBox * scoreBanana) <= scoreTarget;
        }
        else if (score == Inequality.More_Than)
        {
            return (appleInBox * scoreApple) + (bananaInBox * scoreBanana) > scoreTarget;
        }
        else if (score == Inequality.More_Than_Equal)
        {
            return (appleInBox * scoreApple) + (bananaInBox * scoreBanana) >= scoreTarget;
        }
        else
            return false;
    }

    private bool IsAppleCorrect(Inequality apple)
    {
        if (apple == Inequality.Equals)
        {
            return appleInBox == numberTargetApple;
        }
        else if (apple == Inequality.Less_Than)
        {
            return appleInBox < numberTargetApple;
        }
        else if (apple == Inequality.Less_Than_Equal)
        {
            return appleInBox <= numberTargetApple;
        }
        else if (apple == Inequality.More_Than)
        {
            return appleInBox > numberTargetApple;
        }
        else if (apple == Inequality.More_Than_Equal)
        {
            return appleInBox >= numberTargetApple;
        }
        else
            return false;
    }

    private bool IsBananaCorrect(Inequality banana)
    {
        if (banana == Inequality.Equals)
        {
            return bananaInBox == numberTargetBanana;
        }
        else if (banana == Inequality.Less_Than)
        {
            return bananaInBox < numberTargetBanana;
        }
        else if (banana == Inequality.Less_Than_Equal)
        {
            return bananaInBox <= numberTargetBanana;
        }
        else if (banana == Inequality.More_Than)
        {
            return bananaInBox > numberTargetBanana;
        }
        else if (banana == Inequality.More_Than_Equal)
        {
            return bananaInBox >= numberTargetBanana;
        }
        else
            return false;
    }
}
