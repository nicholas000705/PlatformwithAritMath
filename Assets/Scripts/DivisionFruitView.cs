using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DivisionFruitView : MonoBehaviour
{
    [SerializeField] private TextMeshPro appleNumberText;
    [SerializeField] private TextMeshPro bananaNumberText;

    private int viewApple;
    private int viewBanana;

    void Update()
    {
        viewApple = GetComponent<FruitSubmissionPanel>().appleInBox;
        viewBanana = GetComponent<FruitSubmissionPanel>().bananaInBox;

        appleNumberText.text = viewApple.ToString();
        bananaNumberText.text = viewBanana.ToString();
    }
}
