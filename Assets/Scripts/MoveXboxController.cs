using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXboxController : MonoBehaviour
{
    public bool bRight = false;
    Vector3 move;

    void Update()
    {
        if(!bRight)
            move = new Vector3(Input.GetAxis("XboxLeftHorizontal"), Input.GetAxis("XboxLeftVertical"), 0);
        else
            move = new Vector3(Input.GetAxis("XboxRightHorizontal"), Input.GetAxis("XboxRightVertical"), 0);

        transform.position += move * 8f * Time.deltaTime;
    }
}
