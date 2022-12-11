using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Rendering.

public class CameraController : MonoBehaviour
{
    // public PostProcessVolume processVolume;
    // private LensDistortion lensDistortion;
    public float dimensionChangeCam = 0.1f;
    public float moveSmoothnes;
    private float OrjMoveSmoothnes;
    public float rotSmoothnes;

    public Vector3 moveOffset;
    public Vector3 orjMoveOffset;
    public Vector3 rotOffset;

    public Transform target;

    GameSingelton gameSingleton;
    Camera mainCam;
    private void Start()
    {
        // processVolume = GetComponent<PostProcessVolume>();
        // processVolume.profile.TryGetSettings(out lensDistortion);
        mainCam = GetComponent<Camera>();
        gameSingleton = GameSingelton.Instance;
        target = gameSingleton.player.transform;
        orjMoveOffset = moveOffset;
        OrjMoveSmoothnes = moveSmoothnes;
    }
    // private void FixedUpdate()
    // {

    // }

    private void FixedUpdate()
    {
        // if (!GameManager.playerIsAlive)
        // {
        //     target = gameSingleton.player.transform;
        // }
        FollowTarget();
        nosCam();
    }
    // private void LateUpdate() {
    //     FollowTarget();
    // }

    void FollowTarget()
    {
        HandleMovment();
        HandleRotation();
    }
    void HandleMovment()
    {
        Vector3 targetPos = new Vector3();
        targetPos = target.TransformPoint(moveOffset);

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSmoothnes * Time.deltaTime);
    }

    void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = new Quaternion();

        rotation = Quaternion.LookRotation(direction + rotOffset, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSmoothnes * Time.deltaTime);
    }


    float b = 0;
    void nosCam()
    {
        if (gameSingleton.dimensionTransform.scaleCam && b <= dimensionChangeCam)
        {
            // lensDistortion.intensity.value = -1;
            // Mathf.Lerp(mainCam.fieldOfView = 112, mainCam.fieldOfView = 179, 100);
            // mainCam.fieldOfView = 179;
            // mainCam.nearClipPlane = 50f;
            b += Time.deltaTime;
            moveSmoothnes = 6;
            moveOffset.y = 5;
            moveOffset.z = -10;

        }
        else
        {
            // lensDistortion.intensity.value = 1;
            // Mathf.Lerp(mainCam.fieldOfView = 179, mainCam.fieldOfView = 112, 100);
            // mainCam.fieldOfView = 112;
            // mainCam.nearClipPlane = 0.3f;
            moveSmoothnes = OrjMoveSmoothnes;
            moveOffset.z = orjMoveOffset.z;
            moveOffset.y = orjMoveOffset.y;
            gameSingleton.dimensionTransform.scaleCam = false;
            b = 0;
        }
    }

}
