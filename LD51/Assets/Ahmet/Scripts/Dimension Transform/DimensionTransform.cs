using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionTransform : MonoBehaviour
{
    GameSingelton gameSingelton;
    AudioManager audioManager;
    public List<GameObject> Dimensions_1;
    public List<GameObject> Dimensions_2;
    public Material skyboxRef;
    public Texture cubeMap1;
    public Texture cubeMap2;
    public bool dimension_1 = true;

    [Header("Timer")]
    public float time = 5;
    public float maxTime = 10;
    public float minTime = 0;
    public bool scaleCam = false;

    public bool canChangeDimension = true;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
        gameSingelton = GameSingelton.Instance;
        Dimensions_1[0].SetActive(true);
        Dimensions_2[0].SetActive(false);
        dimension_1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeInput();
        DimensionTimer();
        SetUITimer();
    }


    float b = 0;
    public void ChangeInput()
    {
        if (!canChangeDimension)
            return;

        b += Time.deltaTime;
        gameSingelton.uiControl.DimensionChangeTimerSlider.value = b;
        if (b > 1f)
        {
            
            if (Input.GetKeyDown(KeyCode.LeftShift) && Dimensions_1[0].activeSelf == true)
            {
                foreach (var item in Dimensions_1)
                {
                    item.SetActive(false);
                }
                foreach (var item in Dimensions_2)
                {
                    item.SetActive(true);
                }
                // Dimensions_1[0].SetActive(false);
                // Dimensions_1[1].SetActive(true);
                dimension_1 = false;
                // rend.material.SetFloat("_Shininess", shininess);

                skyboxRef.SetTexture("_Tex", cubeMap2);
                Scalaling();
                b = 0;
                audioManager.PlaySound("DimensionChange");
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && Dimensions_1[0].activeSelf == false)
            {
                foreach (var item in Dimensions_2)
                {
                    item.SetActive(false);
                }
                foreach (var item in Dimensions_1)
                {
                    item.SetActive(true);
                }
                // Dimensions_2[0].SetActive(true);
                // Dimensions_2[1].SetActive(false);
                dimension_1 = true;
                skyboxRef.SetTexture("_Tex", cubeMap1);
                Scalaling();
                b = 0;
                audioManager.PlaySound("DimensionChange");
            }
            
        }

    }


    public void DimensionTimer()
    {
        if (!GameManager.playerIsAlive)
            return;

        if (dimension_1)
        {
            time += Time.deltaTime * 1;
        }
        else if (!dimension_1)
        {
            time -= Time.deltaTime * 1;
        }

        if (time <= minTime || time >= maxTime)
        {
            gameSingelton.gameManager.KillPlayer();
            this.enabled = false;
        }
    }

    void SetUITimer()
    {
        gameSingelton.uiControl.timerText.text = (time).ToString("f3");
        gameSingelton.uiControl.timeSlider.value = time;
        gameSingelton.uiControl.timerText.color = gameSingelton.uiControl.timergradient.Evaluate(gameSingelton.uiControl.timeSlider.normalizedValue);
        gameSingelton.uiControl.TimerBarPozitifSlider.value = time;
        gameSingelton.uiControl.TimerBarNegatifSlider.value = time;
        gameSingelton.uiControl.TimerBarPozitifSliderImage.color = gameSingelton.uiControl.timergradient.Evaluate(gameSingelton.uiControl.timeSlider.normalizedValue);
        gameSingelton.uiControl.TimerBarNegatifSliderImage.color = gameSingelton.uiControl.timergradient.Evaluate(gameSingelton.uiControl.timeSlider.normalizedValue);
    }

    public void Scalaling()
    {
        scaleCam = true;
    }
}
