using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CameraController controller;

    public ShipController ship;

    public GameObject player;

    public DimensionTransform dimensionChanger;

    public GameObject[] wheels;

    public GameObject explosionEffect;

    public GameObject losePanel;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            controller.enabled = false;
            ship.enabled = false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            dimensionChanger.canChangeDimension = false;
            GameObject obj = Instantiate(explosionEffect, null);
            obj.transform.position = collision.contacts[0].point;

            foreach (var wheel in wheels)
            {
                wheel.transform.SetParent(null);
                wheel.AddComponent<Rigidbody>();
                wheel.GetComponent<Rigidbody>().mass = .5f;
                wheel.GetComponent<Rigidbody>().AddExplosionForce(.2f, Vector3.zero, .5f);
            }
            losePanel.SetActive(true);


            GameManager.playerIsAlive = false;


            Debug.Log("Coll");
            //Fail
            //Particle - level end
        }
    }
}
