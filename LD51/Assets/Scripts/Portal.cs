using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject city;
    AudioManager audioManager;
    void Start()
    {
        audioManager = AudioManager.instance;
        this.transform.localScale = Vector3.zero;

        this.transform.DOScale(new Vector3(20,20, 0.1122f), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(
                Vector3.forward * 60 * Time.deltaTime
            );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<CarController>().enabled = false;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            SkyboxChanger sc = GameObject.FindObjectOfType<SkyboxChanger>();
            sc.CallChanger(3);
            city.SetActive(false);
            Invoke("GoGameScene", 1.5f);
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void GoGameScene()
    {
        audioManager.StopAllMusics();
        audioManager.state = AudioManager.State.Game;
        SceneManager.LoadScene("YeniAhmet");
        audioManager.SceneStatus();
    }
}
