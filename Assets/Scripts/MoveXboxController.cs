using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXboxController : MonoBehaviour
{
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("XboxHorizontal"), Input.GetAxis("XboxVertical"), 0);
        transform.position += move * 8f * Time.deltaTime;
    }
}
