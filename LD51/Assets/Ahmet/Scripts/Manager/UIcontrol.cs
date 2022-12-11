using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIcontrol : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject TimerBar;
    public GameObject TimerBarPozitif;
    public GameObject TimerBarNegatif;
    public GameObject DimensionChangeTimer;
    public GameObject PauseUI;
    public GameObject SettingsUI;
    public GameObject ScoreUI;


    [Header("UI Elements")]
    public TextMeshProUGUI timerText;
    public Gradient timergradient;
    public Slider timeSlider;
    public TextMeshProUGUI Score_Text;

    public Slider DimensionChangeTimerSlider;
    public Slider TimerBarPozitifSlider;
    public Slider TimerBarNegatifSlider;
    public Image TimerBarPozitifSliderImage;
    public Image TimerBarNegatifSliderImage;
    public Slider MusicVolume;
    public Slider SoundVolume;
    public Toggle TimerTextOpenFalse;

    AudioManager audioManager;
    GameSingelton gameSingelton;
    private void Start()
    {
        gameSingelton = GameSingelton.Instance;
        audioManager = AudioManager.instance;
        MusicVolume.value = audioManager.musics[0].volume;
        SoundVolume.value = audioManager.sounds[0].volume;
    }


    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        PauseUI.SetActive(true);
        GameManager.gameStopped = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseUI.SetActive(false);
        GameManager.gameStopped = false;
    }


    private void Update()
    {
        InputCallUI();
        SetSoundsVolume();
        SetMusicVolume();
        SetTimerText();
        SetScoreText();
    }



    void InputCallUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SettingsUI.activeSelf == false)
        {
            if (GameManager.gameStopped == false)
            {
                PauseGame();
            }
            else if (GameManager.gameStopped == true)
            {
                ResumeGame();
            }

        }
    }


    public void GoSettings()
    {
        SettingsUI.SetActive(true);
        PauseUI.SetActive(false);
    }

    public void BackMenu()
    {
        SettingsUI.SetActive(false);
        PauseUI.SetActive(true);
    }

    public void SetSoundsVolume()
    {
        foreach (var sound in audioManager.sounds)
        {
            sound.volume = SoundVolume.value;
            sound.source.volume = SoundVolume.value;
        }
    }

    public void SetMusicVolume()
    {
        foreach (var music in audioManager.musics)
        {
            music.volume = MusicVolume.value;
            music.source.volume = MusicVolume.value;
        }
    }


    public void SetTimerText()
    {
        if (TimerTextOpenFalse.isOn == true)
        {
            TimerBar.SetActive(true);
        }
        else if (TimerTextOpenFalse.isOn == false)
        {
            TimerBar.SetActive(false);
        }
    }


    float maxScore;
    public void SetScoreText()
    {
        if ((int)gameSingelton.player.transform.position.z <= 0)
        {
            Score_Text.text = 0.ToString();
        }
        else
        {
            if (!GameManager.playerIsAlive)
            {
                if (PlayerPrefs.HasKey("MaxScore")) {
                    if (PlayerPrefs.GetFloat("MaxScore") < maxScore)
                    {
                        PlayerPrefs.SetFloat("MaxScore", maxScore);
                    }
                    return;
                }
                else
                {
                    if(maxScore > 0)
                        PlayerPrefs.SetFloat("MaxScore", maxScore);
                    else
                        PlayerPrefs.SetFloat("MaxScore", 0);
                }
               
            }
            else
            {
                Score_Text.text = ((int)gameSingelton.player.transform.position.z).ToString();
                maxScore = ((int)gameSingelton.player.transform.position.z);
            }
        }
        SetColorText();
    }

    float a = 4;
    float b = 0;
    public void SetColorText()
    {
        if (b <= 0.5f)
        {
            Score_Text.color = Color.LerpUnclamped(Color.yellow, Color.red, 1);
        }
        else if (b <= 1f)
        {
            Score_Text.color = Color.LerpUnclamped(Color.red, Color.blue, 1);
        }
        else if (b <= 1.5f)
        {
            Score_Text.color = Color.LerpUnclamped(Color.blue, Color.magenta, 1);
        }
        else if (b <= 2f)
        {
            Score_Text.color = Color.LerpUnclamped(Color.magenta, new Color(0, 255, 255, 255), 1);
        }
        else if (b <= 2.5f)
        {
            Score_Text.color = Color.LerpUnclamped(new Color(0, 255, 255, 255), Color.green, 1);
        }
        else if (b <= 3f)
        {
            Score_Text.color = Color.LerpUnclamped(Color.green, Color.yellow, 1);
            b = 0;
        }
        b += Time.deltaTime;
    }

}
