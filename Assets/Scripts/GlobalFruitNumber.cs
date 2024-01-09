using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalFruitNumber : MonoBehaviour
{
    public int appleCount;
    public int bananaCount;
    [SerializeField] private TextMeshProUGUI appleText;
    [SerializeField] private TextMeshProUGUI bananaText;

    void Start()
    {
        appleCount = 0;
        bananaCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        appleText.text = appleCount.ToString();
        bananaText.text = bananaCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            appleCount ++;
            AudioManager.instance.PlayEffectSound("Collect");
        }

        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            bananaCount ++;
            AudioManager.instance.PlayEffectSound("Collect");
        }
    }
}
