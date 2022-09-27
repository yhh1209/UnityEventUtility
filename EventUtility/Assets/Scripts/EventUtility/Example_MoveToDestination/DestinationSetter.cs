using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestinationSetter : MonoBehaviour
{
    private Camera _mainCam;
    private Vector3 _destination;
    private PlayerInput _input;
    
    private void Awake()
    {
        _mainCam = Camera.main;
        _input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        #region Old input system
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            _destination = hitInfo.point;
            if (Input.GetMouseButtonDown(0))
            {
                EventManager.BroadCast<Vector3>(EventType.MoveToDestination, _destination);
            }
        }
        #endregion
        
        #region New input system
        //if you are using new input system, use this code
        // Ray ray = _mainCam.ScreenPointToRay(_input.actions["PointerPosition"].ReadValue<Vector2>());
        // RaycastHit hitInfo;
        // if (Physics.Raycast(ray, out hitInfo))
        // {
        //     _destination = hitInfo.point;
        //     if (_input.actions["PointerClick(0)"].triggered)
        //     {
        //         EventManager.BroadCast<Vector3>(EventType.MoveToDestination, _destination);
        //     }
        // }
        #endregion
    }
}
