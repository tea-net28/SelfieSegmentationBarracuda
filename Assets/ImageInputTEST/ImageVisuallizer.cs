using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mediapipe.SelfieSegmentation;
using UnityEngine.UI;

public class ImageVisuallizer : MonoBehaviour
{
    [SerializeField] RawImage inputImageUI;
    [SerializeField] RawImage compositeImage;
    [SerializeField] SelfieSegmentationResource resource;
    [SerializeField] Shader shader;
    [SerializeField] Texture backGroundTexture;

    SelfieSegmentation segmentation;
    Material material;

    private void Awake()
    {
        material = new Material(shader);
        compositeImage.material = material;

        segmentation = new SelfieSegmentation(resource);
    }

    private void LateUpdate()
    {
        segmentation.ProcessImage(inputImageUI.texture);

        compositeImage.texture = segmentation.texture;

        material.SetTexture("_inputImage", inputImageUI.texture);
        material.SetTexture("_backImage", backGroundTexture);
    }

    private void OnApplicationQuit()
    {
        segmentation.Dispose();
    }
}
