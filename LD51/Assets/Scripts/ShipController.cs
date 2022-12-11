using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    public Rigidbody rb;

    //Speed
    public float turnAngle = 60f;
    public float rotateAngle = 45f;
    public float turnSpeed = 5f;
    public float boostSpeed = 45f;
    public float speed = 45f;
    public float nitroSpeed = 6000f;
    public float maxRotateAngle = 25f;
    public float minRotateAngle = -25f;

    public float maxY = 1;
    public float minY = -4f;

    public float max_X = 30;
    public float min_X = -30;


    public float pitchPower, rollPower, yawPower, enginePower;

    private float activeRoll, activePitch, activeYaw;

    public float nitroTime = 2;
    private float currentNitroTime = 0;
    public KeyCode nitroKey = KeyCode.Space;
    bool canUseNitro;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        speed = boostSpeed;
        currentNitroTime = nitroTime;
        canUseNitro = true; 
    }

    private void Update()
    {
        LimitPosition();
        NitroSystem();
    }

    public float GetCurrentNitroTime()
    {
        return currentNitroTime;
    }
    public float GetMaxtNitroTime()
    {
        return nitroTime;
    }

    void NitroSystem()
    {
        if (currentNitroTime > 0 && canUseNitro)
        {
            if (Input.GetKey(nitroKey))
            {
                speed = nitroSpeed;
                currentNitroTime -= Time.deltaTime;
            }
            if (Input.GetKeyUp(nitroKey))
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                speed = boostSpeed;
            }
        }
        else
        {
            Debug.Log("Nitro is done!");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            speed = boostSpeed;
            canUseNitro = false;
            currentNitroTime += Time.deltaTime / 2;
            if (currentNitroTime >= nitroTime)
            {
                canUseNitro = true;
                currentNitroTime = nitroTime;
            }
        }
    }

    private void FixedUpdate()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        float yaw = turnAngle * Input.GetAxis("Horizontal");
        float pitch = turnAngle * Input.GetAxis("Vertical");
        float roll = rotateAngle * Input.GetAxis("Horizontal");
        Quaternion targetRot = Quaternion.Euler(pitch, yaw, roll);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
    }

    void Thrust()
    {
        rb.velocity = (transform.forward * speed * Time.deltaTime);
    }

    void LimitPosition()
    {
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, min_X, max_X), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }
}
