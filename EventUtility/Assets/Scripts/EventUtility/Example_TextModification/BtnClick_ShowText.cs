using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick_ShowText : MonoBehaviour
{
    public string textToShow;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            //broadcast an event for all the subscriber for this event
            EventManager.BroadCast(EventType.ShowText, textToShow);
        });
    }
}
