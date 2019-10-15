using System.Collections;
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
        LogitechController_Right,
        AI
    }

    [HideInInspector] public float dash = 0;
    public Control current = 0;

    MovePointer mv;
    private float TimeLeft = 1.0f;
    private float nextTime = 0.0f;
    private float movementAI = 0;

    public GameObject prefab;
    public int countFish = 1;
    public float fishScale = 1f;

    void Start()
    {
        mv = GetComponent<MovePointer>();
    }

    void Update()
    {
        mv.move = Vector3.zero;

        switch (current)
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
            case Control.AI:
                AI();
                break;
        }

        if (dash != 0)
        {
            mv.move += mv.move * dash;
            dash = 0;
        }
    }

    void AI()
    {

        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            movementAI = Random.Range(1, 5);
        }

        if (movementAI == 1) mv.move += Vector3.left;
        else if (movementAI == 2) mv.move += Vector3.right;
        else if (movementAI == 3) mv.move += Vector3.up;
        else if (movementAI == 4) mv.move += Vector3.down;
    }

    void Keyboard()
    {
        if (Input.GetKey(KeyCode.A)) mv.move += Vector3.left;
        if (Input.GetKey(KeyCode.D)) mv.move += Vector3.right;
        if (Input.GetKey(KeyCode.W)) mv.move += Vector3.up;
        if (Input.GetKey(KeyCode.S)) mv.move += Vector3.down;
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
            mv.move += new Vector3(Input.GetAxis("Xbox" + num + "LeftHorizontal"), Input.GetAxis("Xbox" + num + "LeftVertical"), 0);
        else
            mv.move += new Vector3(Input.GetAxis("Xbox" + num + "RightHorizontal"), Input.GetAxis("Xbox" + num + "RightVertical"), 0);
    }

    void LogitechController(int num, bool bRight)
    {
        if (!bRight)
            mv.move += new Vector3(Input.GetAxis("Xbox" + num + "LeftHorizontal"), Input.GetAxis("Xbox" + num + "LeftVertical"), 0);
        else
            mv.move += new Vector3(Input.GetAxis("LogitechRightHorizontal"), Input.GetAxis("LogitechRightVertical"), 0);
    }
}
