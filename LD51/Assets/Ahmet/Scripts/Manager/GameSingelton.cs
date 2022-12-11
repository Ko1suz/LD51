using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingelton : MonoBehaviour
{
    public GameObject player;
    [HideInInspector]public GameManager gameManager;
    [HideInInspector]public UIcontrol uiControl;
    [HideInInspector]public DimensionTransform dimensionTransform;

    static GameSingelton _instance;

    public static GameSingelton Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GaneSingleton is null!");
            }
            return _instance;
        }
    }
    void Awake()
    {
        _instance = this;
        // DumpReferences();
        LoadReferences();
    }

    void LoadReferences()
    {
        Time.fixedDeltaTime = 0.02f;
        Time.timeScale = 1f;
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GetComponent<GameManager>();
        dimensionTransform = GetComponent<DimensionTransform>();
        uiControl = GetComponent<UIcontrol>();
    }
}
