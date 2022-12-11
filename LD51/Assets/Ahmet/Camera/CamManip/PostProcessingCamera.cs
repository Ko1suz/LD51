using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessingCamera : MonoBehaviour
{
    [SerializeField] Material postPotMat;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination,postPotMat);
    }
}
