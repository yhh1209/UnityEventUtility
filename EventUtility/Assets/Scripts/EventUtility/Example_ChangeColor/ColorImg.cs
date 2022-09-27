using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorImg : MonoBehaviour
{
    private Image _img;
    private void Awake()
    {
        _img = GetComponent<Image>();
        EventManager.AddListener<Color>(EventType.ChangeColor, ChangeColor);
    }

    private void ChangeColor(Color color)
    {
        _img.color = color;
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<Color>(EventType.ChangeColor, ChangeColor);
    }
}
