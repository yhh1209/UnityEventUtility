using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick_SetColor : MonoBehaviour
{
    public Color colorToChange;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            //broadcast an event for all the subscriber for this event
            EventManager.BroadCast(EventType.SetColor, colorToChange);
        });
    }
}
