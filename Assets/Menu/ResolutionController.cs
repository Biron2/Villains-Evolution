using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionController : MonoBehaviour
{
    public Vector2 targetResolution = new Vector2(1920, 1080);

    private float lastScreenWidth;
    private float lastScreenHeight;

    private void Update()
    {
        float currentWidth = Screen.width;
        float currentHeight = Screen.height;

        if (currentWidth != lastScreenWidth || currentHeight != lastScreenHeight)
        {
            UpdateResolution();
            lastScreenWidth = currentWidth;
            lastScreenHeight = currentHeight;
        }
    }

    private void UpdateResolution()
    {
        float targetAspect = targetResolution.x / targetResolution.y;
        float currentAspect = (float)Screen.width / Screen.height;
        float scaleHeight = currentAspect / targetAspect;

        Camera main_camera = Camera.main;
        Rect rect = main_camera.rect;

        if (scaleHeight < 1.0f)
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }

        main_camera.rect = rect;
    }
}