using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Difficult : MonoBehaviour
{
    AudioManager audioManager;
    public TMP_Dropdown secenek;


    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
    }
    
    public void SetDiff()
    {
        if (secenek.value == 0)
        {
           audioManager.diff = AudioManager.Diff.begginer;
        }
        else if (secenek.value == 1)
        {
            audioManager.diff = AudioManager.Diff.mid;
        }
         else if (secenek.value == 2)
        {
            audioManager.diff = AudioManager.Diff.hard;
        }
    }
}
