using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartCanvasAnim : MonoBehaviour
{
    public GameObject buddy;

    void Update()
    {
        buddy.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(buddy.GetComponent<RectTransform>().anchoredPosition, new Vector2(-523, 143), 1f * Time.deltaTime);
    }
}
