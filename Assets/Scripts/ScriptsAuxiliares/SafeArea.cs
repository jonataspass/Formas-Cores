﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    RectTransform rectTransform;
    Rect safeArea;
    Vector2 maxAnchor;
    Vector2 minAnchor;

    private void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();
        //safeArea = Screen.safeArea;
        //minAnchor = safeArea.position;
        //maxAnchor = minAnchor + safeArea.size;

        //minAnchor.x /= Screen.width;
        //minAnchor.y /= Screen.height;
        //maxAnchor.x /= Screen.width;
        //maxAnchor.y /= Screen.height;

        //rectTransform.anchorMin = minAnchor;
        //rectTransform.anchorMax = maxAnchor;
    }

    public void SafeA()
    {
        rectTransform = GetComponent<RectTransform>();
        safeArea = Screen.safeArea;
        minAnchor = safeArea.position;
        maxAnchor = minAnchor + safeArea.size;

        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;

        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }
}
