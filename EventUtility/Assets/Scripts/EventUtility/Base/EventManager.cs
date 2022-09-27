using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    //dictionary of event and event listeners
    private static Dictionary<EventType, Delegate> m_EventList = new Dictionary<EventType, Delegate>();

    //call when a script register a listener for an event
    //this function determines whether the target event type exists in the dictionary, and whether the listener to be added already exists
    private static void OnListenerAdd(EventType eventType, Delegate callBackFunc)
    {
        //if there is no event of the target event type in dictionary
        //add event type to dictionary for prepare add listeners for target event type
        if (!m_EventList.ContainsKey(eventType))
        {
            m_EventList.Add(eventType, null);
        }

        
        Delegate temp = m_EventList[eventType];
        //throw an exception when the listener already exist in the dictionary
        if (temp != null && temp.GetType() != callBackFunc.GetType())
        {
            throw new Exception(string.Format("Add listener error: Try to add different delegate to event {0}" +
                                              ", current delegate of event is {1}" +
                                              ", type of delegate to add is {2}."
                , eventType, temp.GetType(), callBackFunc.GetType()));
        }
    }

    //call when a script unregister a listener for an event
    //this function determines whether the target event type exists in the dictionary, and whether the listener was added exists
    private static void OnListenerRemove(EventType eventType, Delegate callBackFunc)
    {
        //if target event type exists in the dictionary
        if (m_EventList.ContainsKey(eventType))
        {
            Delegate temp = m_EventList[eventType];
            //throw an exception when there is no listener for this event
            if (temp == null)
            {
                throw new Exception(string.Format("Remove listener error: Event {0} have no delegate.", eventType));
            }
            //throw an exception when the target listener type different with the listener type for the target event
            else if (temp.GetType() != callBackFunc.GetType())
            {
                throw new Exception(string.Format("Remove listener error: Trying to remove different type of delegate from {0}, " +
                                                  "current delegate type is {1}, type of delegate to remove is {2}."
                    ,eventType, temp.GetType(), callBackFunc.GetType()));
            }
        }
        else
        {
            //throw an exception when the target event type not exists in the dictionary
            throw new Exception(string.Format("Remove listener error: Event {0} not found.", eventType));
        }
    }

    //call when an listener removed
    //this function remove target event type when the target event type have no listener
    private static void OnListenerRemoved(EventType eventType)
    {
        if (m_EventList[eventType] == null)
        {
            m_EventList.Remove(eventType);
        }
    }
    
    //Add event delegate with no parameters.
    public static void AddListener(EventType eventType, CallbackFunc callBackFunc)
    {
        OnListenerAdd(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc)m_EventList[eventType] + callBackFunc;
    }

    //Add event delegate with one parameters.
    public static void AddListener<T>(EventType eventType, CallbackFunc<T> callBackFunc)
    {
        OnListenerAdd(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc<T>)m_EventList[eventType] + callBackFunc;
    }
    
    public static void AddListener<T,X>(EventType eventType, CallbackFunc<T,X> callBackFunc)
    {
        OnListenerAdd(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc<T,X>)m_EventList[eventType] + callBackFunc;
    }
    
    public static void AddListener<X,Y,Z>(EventType eventType, CallbackFunc<X,Y,Z> callBackFunc)
    {
        OnListenerAdd(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc<X,Y,Z>)m_EventList[eventType] + callBackFunc;
    }
    
    public static void AddListener<X,Y,Z,W>(EventType eventType, CallbackFunc<X,Y,Z,W> callBackFunc)
    {
        OnListenerAdd(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc<X,Y,Z,W>)m_EventList[eventType] + callBackFunc;
    }
    
    public static void AddListener<X,Y,Z,W,T>(EventType eventType, CallbackFunc<X,Y,Z,W,T> callBackFunc)
    {
        OnListenerAdd(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc<X,Y,Z,W,T>)m_EventList[eventType] + callBackFunc;
    }
    
    //remove event delegate with no parameters.
    public static void RemoveListener(EventType eventType, CallbackFunc callBackFunc)
    {
        OnListenerRemove(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc)m_EventList[eventType] - callBackFunc;
        OnListenerRemoved(eventType);
    }

    //Remove a delegate from an event with one param.
    public static void RemoveListener<T>(EventType eventType, CallbackFunc<T> callBackFunc)
    {
        OnListenerRemove(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc<T>)m_EventList[eventType] - callBackFunc;
        OnListenerRemoved(eventType);
    }
    
    public static void RemoveListener<T,X>(EventType eventType, CallbackFunc<T,X> callBackFunc)
    {
        OnListenerRemove(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc<T,X>)m_EventList[eventType] - callBackFunc;
        OnListenerRemoved(eventType);
    }
    
    public static void RemoveListener<X,Y,Z>(EventType eventType, CallbackFunc<X,Y,Z> callBackFunc)
    {
        OnListenerRemove(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc<X,Y,Z>)m_EventList[eventType] - callBackFunc;
        OnListenerRemoved(eventType);
    }
    
    public static void RemoveListener<X,Y,Z,W>(EventType eventType, CallbackFunc<X,Y,Z,W> callBackFunc)
    {
        OnListenerRemove(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc<X,Y,Z,W>)m_EventList[eventType] - callBackFunc;
        OnListenerRemoved(eventType);
    }
    
    public static void RemoveListener<X,Y,Z,W,T>(EventType eventType, CallbackFunc<X,Y,Z,W,T> callBackFunc)
    {
        OnListenerRemove(eventType, callBackFunc);

        m_EventList[eventType] = (CallbackFunc<X,Y,Z,W,T>)m_EventList[eventType] - callBackFunc;
        OnListenerRemoved(eventType);
    }

    //Broadcast delegate with no parameters.
    public static void BroadCast(EventType eventType)
    {
        Delegate temp;
        //check the target event type exists in the dictionary
        if (m_EventList.TryGetValue(eventType, out temp))
        {
            CallbackFunc callbackFunc = temp as CallbackFunc;
            if (callbackFunc != null)
            {
                callbackFunc();
            }
            else
            {
                throw new Exception(String.Format("Broadcast error: Event {0} have different type of delegate", eventType));
            }
        }
    }
    
    //Broadcast delegate with one parameters.
    public static void BroadCast<T>(EventType eventType, T param)
    {
        Delegate temp;
        if (m_EventList.TryGetValue(eventType, out temp))
        {
            CallbackFunc<T> callbackFunc = temp as CallbackFunc<T>;
            if (callbackFunc != null)
            {
                callbackFunc(param);
            }
            else
            {
                throw new Exception(String.Format("Broadcast error: Event {0} have different type of delegate", eventType));
            }
        }
    }
    
    public static void BroadCast<T,X>(EventType eventType, T param1, X param2)
    {
        Delegate temp;
        if (m_EventList.TryGetValue(eventType, out temp))
        {
            CallbackFunc<T,X> callbackFunc = temp as CallbackFunc<T,X>;
            if (callbackFunc != null)
            {
                callbackFunc(param1, param2);
            }
            else
            {
                throw new Exception(String.Format("Broadcast error: Event {0} have different type of delegate", eventType));
            }
        }
    }
    
    public static void BroadCast<X,Y,Z>(EventType eventType, X param1, Y param2, Z param3)
    {
        Delegate temp;
        if (m_EventList.TryGetValue(eventType, out temp))
        {
            CallbackFunc<X,Y,Z> callbackFunc = temp as CallbackFunc<X,Y,Z>;
            if (callbackFunc != null)
            {
                callbackFunc(param1, param2, param3);
            }
            else
            {
                throw new Exception(String.Format("Broadcast error: Event {0} have different type of delegate", eventType));
            }
        }
    }
    
    public static void BroadCast<X,Y,Z,W>(EventType eventType, X param1, Y param2, Z param3, W param4)
    {
        Delegate temp;
        if (m_EventList.TryGetValue(eventType, out temp))
        {
            CallbackFunc<X, Y, Z, W> callbackFunc = temp as CallbackFunc<X, Y, Z, W>;
            if (callbackFunc != null)
            {
                callbackFunc(param1, param2, param3, param4);
            }
            else
            {
                throw new Exception(String.Format("Broadcast error: Event {0} have different type of delegate", eventType));
            }
        }
    }
    
    public static void BroadCast<X,Y,Z,W,T>(EventType eventType, X param1, Y param2, Z param3, W param4, T param5)
    {
        Delegate temp;
        if (m_EventList.TryGetValue(eventType, out temp))
        {
            CallbackFunc<X,Y,Z,W,T> callbackFunc = temp as CallbackFunc<X,Y,Z,W,T>;
            if (callbackFunc != null)
            {
                callbackFunc(param1, param2, param3, param4, param5);
            }
            else
            {
                throw new Exception(String.Format("Broadcast error: Event {0} have different type of delegate", eventType));
            }
        }
    }
    
}
