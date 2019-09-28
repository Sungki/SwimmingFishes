using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform target1;
    public Transform target2;

    Camera cam;
    Vector3 originalPos;


    void Start()
    {
        cam = GetComponent<Camera>();
        originalPos = cam.transform.position;
    }

    void Update()
    {
        Vector3 midpoint = (target1.position + target2.position) / 2f;
        float distance = (target1.position - target2.position).magnitude;

        if(distance < 4f)
        {
            Vector3 cameraDestination = midpoint - cam.transform.forward * distance * 1.5f;

            if (cameraDestination.z > -5f)
            {
                cameraDestination.z = -5f;
            }

            if (cameraDestination.z < -15f)
            {
                cameraDestination.z = -15f;
            }

            cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, 0.05f);
        }
        else
        {
            cam.transform.position = Vector3.Slerp(cam.transform.position, originalPos, 0.05f);
        }

/*        cam.transform.LookAt(midpoint);

                if ((cameraDestination - cam.transform.position).magnitude <= 0.1f)
                    cam.transform.position = cameraDestination;



                float distance = Vector3.Distance(target2.position,target1.position)*2f;

                if (cam.fieldOfView <= 20.0f)
                {
                    cam.fieldOfView = 20.0f;
                }
                else if (cam.fieldOfView >= 90.0f)
                {
                    cam.fieldOfView = 90.0f;
                }
                else
                {
                    cam.fieldOfView += distance;
                }

                Vector3 mid;
                mid.x = target1.position.x + (target2.position.x - target1.position.x) / 2;
                mid.y = target1.position.y + (target2.position.y - target1.position.y) / 2;
                mid.z = 0;
                transform.LookAt(mid);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.15f);
                if (Input.GetMouseButtonDown(1))
                { isZoomed = !isZoomed; }
                if (isZoomed)
                { GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth); }
                else
                { GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth); }*/
    }
}
