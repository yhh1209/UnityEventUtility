using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBtn : MonoBehaviour
{
    private Image _img;
    private void Awake()
    {
        _img = GetComponent<Image>();
        EventManager.AddListener<Color>(EventType.SetColor, SetColor);
    }

    private void SetColor(Color color)
    {
        _img.color = color;
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<Color>(EventType.SetColor, SetColor);
    }
}
