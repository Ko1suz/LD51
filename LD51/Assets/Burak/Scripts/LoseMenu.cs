using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseMenu : MonoBehaviour
{
    public string[] loseTexts;

    public TextMeshProUGUI loseTMP;

    private void Start()
    {
        if (loseTexts.Length == 0)
        {
            loseTMP.SetText("U ded lol");
        }
        else
        {
            loseTMP.SetText(loseTexts[Random.Range(0, loseTexts.Length - 1)]);
        }
        
    }
}
