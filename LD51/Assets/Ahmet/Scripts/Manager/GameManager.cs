using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro.Examples;

public class GameManager : MonoBehaviour
{
    GameSingelton gameSingelton;
    public static bool playerIsAlive = true;
    [HideInInspector]public static bool gameStopped = false;
    public GameObject timeLoseCanvas;
    public CameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        gameStopped = false;
        gameSingelton = GameSingelton.Instance;
        playerIsAlive = true;
    }


    public void KillPlayer()
    {
        //gameSingelton.player.SetActive(false);
        gameSingelton.player.transform.DOScale(Vector3.zero, 1.5f);
        cameraController.enabled = false;
        gameSingelton.player.GetComponent<ShipController>().enabled = false;
        gameSingelton.player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameSingelton.player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        if (timeLoseCanvas != null)
            timeLoseCanvas.SetActive(true);
        /*Time.fixedDeltaTime = 0.01f;
        Time.timeScale = 0.1f;*/
        playerIsAlive = false;
    }
}
