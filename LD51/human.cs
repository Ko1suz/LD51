using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class human : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
<<<<<<< Updated upstream
        this.transform.DOMove(new Vector3(target.position.x, transform.position.y, target.position.z), 5f).OnComplete(() => {
=======
        this.transform.DOMove(new Vector3(target.position.x, transform.position.y, target.position.z), 4f).OnComplete(() => {
>>>>>>> Stashed changes
            Destroy(this.gameObject);
        });
    }
}
