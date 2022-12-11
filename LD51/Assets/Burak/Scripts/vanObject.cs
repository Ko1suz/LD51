using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanObject : MonoBehaviour
{
    Rigidbody rb;
    float speed;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        speed = Random.Range(2000, 5000);
    }
    private void FixedUpdate()
    {
        rb.velocity = (new Vector3(0,0, -1) * speed * Time.deltaTime);
    }
}
