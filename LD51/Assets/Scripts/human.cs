using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class human : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        this.transform.DOMove(new Vector3(target.position.x, transform.position.y, target.position.z), 5f);
    }

    private void Update()
    {
        this.transform.LookAt(target);
        if (Vector3.Distance(this.transform.position, target.position) < 1.5)
        {
            Destroy(this.gameObject);
        }
    }
}
