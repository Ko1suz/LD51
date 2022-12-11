using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideObj : MonoBehaviour
{
    public bool isNeg = false;
    private void Start()
    {
        if(!isNeg)
            transform.DOMoveY(transform.position.y + 1200, Random.Range(5f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        else
            transform.DOMoveY(transform.position.y - 2000, Random.Range(5f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
