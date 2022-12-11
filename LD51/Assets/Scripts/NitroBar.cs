using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroBar : MonoBehaviour
{
    ShipController controller;

    private float nitroAmount;
    private float maxNitroAmount;

    public Image nitroSlider;


    private void Awake()
    {
        controller = GetComponent<ShipController>();
    }

    private void Start()
    {
        maxNitroAmount = controller.GetMaxtNitroTime();
        nitroAmount = maxNitroAmount;
    }

    private void Update()
    {
        nitroSlider.fillAmount = controller.GetCurrentNitroTime() / maxNitroAmount;
    }
}
