﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovePointer))]
public class SelectControl : MonoBehaviour
{
    public enum Control
    {
        Keyboard_WASD,
        Mouse,
        XboxController_1_Left,
        XboxController_1_Right,
        XboxController_2_Left,
        XboxController_2_Right,
        LogitechController_Left,
        LogitechController_Right
    }

    [SerializeField] Control current = 0;
    [HideInInspector] public float dash = 0;
    MovePointer mv;

    void Start()
    {
        mv = GetComponent<MovePointer>();
    }

    void Update()
    {
        switch(current)
        {
            case Control.Keyboard_WASD:
                Keyboard();
                break;
            case Control.Mouse:
                Mouse();
                break;
            case Control.XboxController_1_Left:
                XboxController(1, false);
                break;
            case Control.XboxController_1_Right:
                XboxController(1, true);
                break;
            case Control.XboxController_2_Left:
                XboxController(2, false);
                break;
            case Control.XboxController_2_Right:
                XboxController(2, true);
                break;
            case Control.LogitechController_Left:
                LogitechController(1, false);
                break;
            case Control.LogitechController_Right:
                LogitechController(1, true);
                break;

        }
    }

    void Keyboard()
    {
        mv.move = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) mv.move += Vector3.left;
        if (Input.GetKey(KeyCode.D)) mv.move += Vector3.right;
        if (Input.GetKey(KeyCode.W)) mv.move += Vector3.up;
        if (Input.GetKey(KeyCode.S)) mv.move += Vector3.down;
        if (dash != 0)
        {
            mv.move += mv.move * dash;
            dash = 0;
        }
    }

    void Mouse()
    {
        Vector3 mousePos = GetWorldPositionOnPlane(Input.mousePosition, 0);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    void XboxController(int num, bool bRight)
    {
        if (!bRight)
            mv.move = new Vector3(Input.GetAxis("Xbox" + num + "LeftHorizontal"), Input.GetAxis("Xbox" + num + "LeftVertical"), 0);
        else
            mv.move = new Vector3(Input.GetAxis("Xbox" + num + "RightHorizontal"), Input.GetAxis("Xbox" + num + "RightVertical"), 0);
    }

    void LogitechController(int num, bool bRight)
    {
        if (!bRight)
            mv.move = new Vector3(Input.GetAxis("Xbox" + num + "LeftHorizontal"), Input.GetAxis("Xbox" + num + "LeftVertical"), 0);
        else
            mv.move = new Vector3(Input.GetAxis("LogitechRightHorizontal"), Input.GetAxis("LogitechRightVertical"), 0);
    }
}