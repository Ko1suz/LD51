using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethods : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.instance;
    }
    public void GoCityScene()
    {
        audioManager = AudioManager.instance;
        audioManager.StopAllMusics();
        SceneManager.LoadScene("CityScene");
        audioManager.state = AudioManager.State.City;
        audioManager.SceneStatus();
    }

    public void GoMainMenu()
    {
        audioManager = AudioManager.instance;
        audioManager.StopAllMusics();
        SceneManager.LoadScene("MainMenu");
        audioManager.state = AudioManager.State.mainMenu;
        audioManager.SceneStatus();
    }

    public void GoGameScene()
    {
        audioManager = AudioManager.instance;
        audioManager.StopAllMusics();
        SceneManager.LoadScene("YeniAhmet");
        audioManager.state = AudioManager.State.Game;
        audioManager.SceneStatus();
    }
    public void GoRestart()
    {
        audioManager = AudioManager.instance;
        SceneManager.LoadScene("CitySceneWOT");
        audioManager.StopAllMusics();
        audioManager.state = AudioManager.State.City;
        audioManager.SceneStatus();
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
