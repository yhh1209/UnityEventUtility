using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick_ChangeColor : MonoBehaviour
{
    public Color colorToChange;
    private void Awake()
    {
        EventManager.AddListener<Color>(EventType.SetColor, SetColor);
        GetComponent<Button>().onClick.AddListener(() =>
        {
            //broadcast an event for all the subscriber for this event
            EventManager.BroadCast(EventType.ChangeColor, colorToChange);
        });
    }

    private void SetColor(Color color)
    {
        colorToChange = color;
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<Color>(EventType.SetColor, SetColor);
    }
}
