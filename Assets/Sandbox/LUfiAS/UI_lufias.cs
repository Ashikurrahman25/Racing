using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_lufias : MonoBehaviour
{
    public static UI_lufias instance;    
    public Text currentScoreText;
    public Image progressFill;

    int targetNum = 5, currentNum = 0;
    public float fill;
    private void Awake()
    {
        instance = this;
    }

    public void UpdateUI()
    {

        currentNum++;
        currentScoreText.text = $"{currentNum}/{targetNum}";
        fill = (float)currentNum / (float)targetNum;
        progressFill.fillAmount = fill;
        if (currentNum >= targetNum)
        {
            print("level completed :)");
        }
    }

    
}
