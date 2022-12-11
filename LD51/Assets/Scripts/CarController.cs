using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private List<WheelCollider> wheelColliders;
    [SerializeField] private List<Transform> wheelTransforms;

    [Header("Motor Settings")]
    [SerializeField] private float enginePower = 200;
    [SerializeField] private float breakPower = 400;


    [Header("Keyboard Inputs")]
    [SerializeField] private KeyCode gasKey_K = KeyCode.W;
    [SerializeField] private KeyCode brakeKey_K = KeyCode.S;
    [SerializeField] private KeyCode handbreakKey_K = KeyCode.Space;
    [SerializeField] private KeyCode nitroKey_K = KeyCode.LeftShift;
    [Header("Gamepad Inputs")]
    [SerializeField] private KeyCode gasKey_G = KeyCode.Joystick1Button10;
    [SerializeField] private KeyCode brakeKey_G = KeyCode.Joystick1Button9;
    [SerializeField] private KeyCode handbreakKey_G = KeyCode.Joystick1Button0;
    [SerializeField] private KeyCode nitroKey_G = KeyCode.Joystick1Button1;
    //Input private region
    private float steeringInput;
    private float steeringAngle;
    private float gasInput;
    private float brakeInput;
    [SerializeField] private float radius = 6f;
    [SerializeField] private float maxSteerAngle = 30;
    [SerializeField] private float turnSens = 1f;
    private bool isPressGas;
    private bool isPressBrake;
    private bool isPressHandbrake;
    private bool isPressNitro;
    public bool canSteer = true;

    enum DriveType
    {
        frontWheelDrive,
        rearWheelDrive,
        allWheelDrive
    }
    [SerializeField] DriveType driveType;


    [SerializeField] private Rigidbody rb;
    public Vector3 centerOfMass;

    private void Awake()
    {
        rb.centerOfMass = centerOfMass;
        rb.useGravity = true;
    }

    private void Update()
    {
        GetInputs();
        UpdateWheelPoses();
    }

    private void GetInputs()
    {
        steeringInput = Input.GetAxis("Horizontal");
        gasInput = Input.GetAxis("Vertical");
        brakeInput = Input.GetAxis("Brake");
        isPressGas = Input.GetKey(gasKey_K);

        if (Input.GetAxis("Brake") != 0 || Input.GetKey(brakeKey_K))
        {
            isPressBrake = true;
        }
        else
        {
            isPressBrake = false;
        }

        if (Input.GetKey(handbreakKey_G) || Input.GetKey(handbreakKey_K))
        {
            isPressHandbrake = true;
        }
        else
        {
            isPressHandbrake = false;
        }

        if (Input.GetKey(nitroKey_G) || Input.GetKey(nitroKey_K))
        {
            isPressNitro = true;
        }
        else
        {
            isPressNitro = false;
        }
    }

    private void FixedUpdate()
    {
        Accelerate();
        //Breake();
        //Steer();
    }

    private void Accelerate()
    {
        if (isPressGas)
        {
            if (driveType == DriveType.allWheelDrive)
            {
                foreach (var wheel in wheelColliders)
                {
                    if(Input.GetKey(gasKey_K))
                        wheel.motorTorque = 1 * (enginePower / 4);
                }
            }
            else if (driveType == DriveType.frontWheelDrive)
            {
                for (int i = 0; i < wheelColliders.Count - 2; i++)
                {
                    if (Input.GetKey(gasKey_K))
                        wheelColliders[i].motorTorque = 1 * (enginePower / 2);
                }
            }
            else if (driveType == DriveType.rearWheelDrive)
            {
                for (int i = 2; i < wheelColliders.Count; i++)
                {
                    if (Input.GetKey(gasKey_K))
                        wheelColliders[i].motorTorque = 1 * (enginePower / 2);
                }

            }
        }
        else
        {
            for (int i = 0; i < wheelColliders.Count; i++)
            {
                wheelColliders[i].motorTorque = 0;
            }
        }
    }

    private void Breake()
    {
        if (isPressBrake)
        {
            for (int i = 0; i < wheelColliders.Count; i++)
            {
                wheelColliders[i].brakeTorque = -brakeInput * breakPower;
            }
        }
        else
        {
            for (int i = 0; i < wheelColliders.Count; i++)
            {
                wheelColliders[i].brakeTorque = 0;
            }
        }
    }

    private void Steer()
    {
        /*if (gasInput > 0)
        {
            wheelColliders[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * gasInput;
            wheelColliders[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * gasInput;
        }
        else if (gasInput < 0)
        {
            wheelColliders[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * gasInput;
            wheelColliders[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * gasInput;
        }
        else
        {
            wheelColliders[0].steerAngle = 0f;
            wheelColliders[1].steerAngle = 0f;
        }*/

        if (!canSteer)
            return;

        steeringAngle = maxSteerAngle * turnSens * steeringInput;

        wheelColliders[0].steerAngle = Mathf.Lerp(wheelColliders[0].steerAngle, steeringAngle, .6f);
        wheelColliders[1].steerAngle = Mathf.Lerp(wheelColliders[1].steerAngle, steeringAngle, .6f);
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(wheelColliders[0], wheelTransforms[0]);
        UpdateWheelPose(wheelColliders[1], wheelTransforms[1]);
        UpdateWheelPose(wheelColliders[2], wheelTransforms[2]);
        UpdateWheelPose(wheelColliders[3], wheelTransforms[3]);
    }

    private void UpdateWheelPose(WheelCollider _wheelCollider, Transform _wheelTransform)
    {
        Vector3 pos = _wheelTransform.position;
        Quaternion quat = _wheelTransform.rotation;

        _wheelCollider.GetWorldPose(out pos, out quat);

        _wheelTransform.position = pos;
        _wheelTransform.rotation = quat;
    }

}
