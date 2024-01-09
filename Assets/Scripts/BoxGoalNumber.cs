using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxGoalNumber : MonoBehaviour
{
    private FruitSubmissionPanel[] fruitSubmissionPanels;
    private GameObject[] totalBoxNumber;
    [SerializeField] private TextMeshProUGUI currentBoxNumberText;
    [SerializeField] private TextMeshProUGUI totalBoxNumberText;
    private int currentBoxAchieved;
    public bool isCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        totalBoxNumber = GameObject.FindGameObjectsWithTag("Box");
        fruitSubmissionPanels = FindObjectsOfType<FruitSubmissionPanel>();
    }

     // Update is called once per frame
    void Update()
    {
        foreach (var panel in fruitSubmissionPanels)
        {
            currentBoxAchieved += panel.BoxCalculate();
        }

        currentBoxNumberText.text = currentBoxAchieved.ToString();
        totalBoxNumberText.text = totalBoxNumber.Length.ToString();

        if(currentBoxAchieved == totalBoxNumber.Length)
        {
            isCompleted = true;
        }
    }
}
