using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SkyboxChanger : MonoBehaviour
{
    [Header("Current Skybox Stats")]
    public Material currMaterial;
    [Range(0f, 5f)] public float currExposure;
    [Header("Next Skybox Stats")]
    public Material nextMaterial;
    [Range(0f, 5f)] public float nextExposure;


    public bool workOnStart = true;

    void Start()
    {
        RenderSettings.skybox = currMaterial;
        nextMaterial.SetFloat("_Rotation", 0);
        currMaterial.SetFloat("_Exposure", currExposure);
        RenderSettings.skybox.SetFloat("_Exposure", currExposure);

        if(workOnStart)
            StartCoroutine(Changer());
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Changer());
        }*/
    }

    float percent;
    float f = 0;


    IEnumerator Changer()
    {
        yield return null;

        float timer = 0;
        while (timer < 4)
        {
            percent += Time.deltaTime * 255;
            f += Time.deltaTime * percent;
            RenderSettings.skybox.SetFloat("_Rotation", (f));
            RenderSettings.skybox.SetFloat("_Exposure", RenderSettings.skybox.GetFloat("_Exposure") + Time.deltaTime * 2);
            nextMaterial.SetFloat("_Exposure", RenderSettings.skybox.GetFloat("_Exposure"));
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0;

        RenderSettings.skybox = nextMaterial;
        currMaterial.SetFloat("_Exposure", currExposure);
        currMaterial.SetFloat("_Rotation", 0);

        while (percent > .2f)
        {
            percent = Mathf.Lerp(percent, 0, Time.deltaTime);
            f += Time.deltaTime * percent;
            RenderSettings.skybox.SetFloat("_Rotation", (f));
            RenderSettings.skybox.SetFloat("_Exposure", Mathf.Lerp(RenderSettings.skybox.GetFloat("_Exposure"), nextExposure, Time.deltaTime));

            yield return null;
        }
    }

    IEnumerator Changer(float value)
    {
        yield return null;

        float timer = 0;
        while (timer < value)
        {
            percent += Time.deltaTime * 255;
            f += Time.deltaTime * percent;
            RenderSettings.skybox.SetFloat("_Rotation", (f));
            RenderSettings.skybox.SetFloat("_Exposure", RenderSettings.skybox.GetFloat("_Exposure") + Time.deltaTime * 2);
            nextMaterial.SetFloat("_Exposure", RenderSettings.skybox.GetFloat("_Exposure"));
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0;

        RenderSettings.skybox = nextMaterial;
        currMaterial.SetFloat("_Exposure", currExposure);
        currMaterial.SetFloat("_Rotation", 0);

        while (percent > .2f)
        {
            percent = Mathf.Lerp(percent, 0, Time.deltaTime);
            f += Time.deltaTime * percent;
            RenderSettings.skybox.SetFloat("_Rotation", (f));
            RenderSettings.skybox.SetFloat("_Exposure", Mathf.Lerp(RenderSettings.skybox.GetFloat("_Exposure"), nextExposure, Time.deltaTime));

            yield return null;
        }
    }

    public void CallChanger(float value)
    {
        StartCoroutine(Changer(value));
    }




}
