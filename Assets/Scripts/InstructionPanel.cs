using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionPanel : MonoBehaviour
{
    [SerializeField] GameObject[] instructionUI;
    private int currentNumberOfInstructionPage;

    // Start is called before the first frame update
    void Start()
    {
        currentNumberOfInstructionPage = 0;

        if (SceneManager.GetActiveScene().buildIndex == 2 && PlayerPrefs.GetInt("LevelSaved") < 3)
        {
            StartCoroutine(DelayPopUp(2f));
        }
    }

    public void OpenInstructionPage()
    {
        instructionUI[currentNumberOfInstructionPage].SetActive(true);
        AudioManager.instance.PlayEffectSound("Select");
    }

    public void PreviousInstructionPage()
    {
        instructionUI[currentNumberOfInstructionPage].SetActive(false);
        currentNumberOfInstructionPage -= 1;
        instructionUI[currentNumberOfInstructionPage].SetActive(true);
        AudioManager.instance.PlayEffectSound("Select");
    }

    public void NextInstructionPage()
    {
        instructionUI[currentNumberOfInstructionPage].SetActive(false);
        currentNumberOfInstructionPage += 1;
        instructionUI[currentNumberOfInstructionPage].SetActive(true);
        AudioManager.instance.PlayEffectSound("Select");
    }

    public void CloseInstructionPage() 
    {
        instructionUI[currentNumberOfInstructionPage].SetActive(false);
        AudioManager.instance.PlayEffectSound("Back/Resume");
    }

    IEnumerator DelayPopUp(float time)
    {
        yield return new WaitForSeconds(time);
        instructionUI[currentNumberOfInstructionPage].SetActive(true);
    }
}
