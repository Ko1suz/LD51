using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartMaxScore : MonoBehaviour
{

    public float maxScore;
    public TextMeshProUGUI maxScoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            maxScore = PlayerPrefs.GetFloat("MaxScore");
            maxScoreText.text = "Max Score = " + maxScore;
        }
        else
        {
            maxScoreText.text = "Play for high score";
        }
        
    }
}
