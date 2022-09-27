using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowText : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
        //register a listener if a script need to subscribe an event
        //don't register an event multiple times
        EventManager.AddListener<string>(EventType.ShowText, Show);
    }

    private void OnDestroy()
    {
        //if a script subscribed an event, must unregister a listener for that event on destroy
        //the callback function must same as the listener registration
        EventManager.RemoveListener<string>(EventType.ShowText, Show);
    }
    
    //the callback function for the event 'ShowText'
    private void Show(string str)
    {
        gameObject.SetActive(true);
        GetComponent<TextMeshProUGUI>().text = str;
    }
}
