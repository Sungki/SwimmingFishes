using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    SelectControl sc;
    ParticleSystem ps;
    GameObject[] fish;
    private bool m_isAxisInUse = false;

    public float waitingTime = 15.0f;
    bool canAttack = true;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        sc = GetComponent<SelectControl>();

        fish = new GameObject[sc.countFish];

        for (int i = 0; i < sc.countFish; i++)
        {
            fish[i] = Instantiate(sc.prefab, transform.position + Vector3.left * i, Quaternion.identity);
            fish[i].GetComponent<FollowTarget>().target = this.gameObject;
            fish[i].transform.localScale = new Vector3(sc.fishScale, sc.fishScale, sc.fishScale);

            if (tag == "LeftFish")
            {
                fish[i].GetComponent<Attack>().current = Attack.FishSide.LeftFish;
                fish[i].gameObject.tag = "LeftFish";
                fish[i].GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            }
            else
            {
                fish[i].GetComponent<Attack>().current = Attack.FishSide.RightFish;
                fish[i].gameObject.tag = "RightFish";
                fish[i].GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
        }
    }

    void Update()
    {
        switch (sc.current)
        {
            case SelectControl.Control.Keyboard_WASD:
                Keyboard();
                break;
            case SelectControl.Control.Mouse:
                Mouse();
                break;
            case SelectControl.Control.XboxController_1_Left:
                XboxController(1, false);
                break;
            case SelectControl.Control.XboxController_1_Right:
                XboxController(1, true);
                break;
            case SelectControl.Control.XboxController_2_Left:
                XboxController(2, false);
                break;
            case SelectControl.Control.XboxController_2_Right:
                XboxController(2, true);
                break;
            case SelectControl.Control.LogitechController_Left:
                LogitechController(false);
                break;
            case SelectControl.Control.LogitechController_Right:
                LogitechController(true);
                break;
            case SelectControl.Control.AI:
                break;
        }
    }

    void Keyboard()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateCube();
        }
    }

    void Mouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateCube();
        }
    }

    void XboxController(int num, bool bRight)
    {
        if (!bRight)
        {
            if (Input.GetAxisRaw("Xbox" + num + "LeftTrigger") != 0)
            {
                if (m_isAxisInUse == false)
                {
                    CreateCube();
                    m_isAxisInUse = true;
                }
            }

            if (Input.GetAxisRaw("Xbox" + num + "LeftTrigger") == 0)
            {
                m_isAxisInUse = false;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Xbox" + num + "RightTrigger") != 0)
            {
                if (m_isAxisInUse == false)
                {
                    CreateCube();
                    m_isAxisInUse = true;
                }
            }
            if (Input.GetAxisRaw("Xbox" + num + "RightTrigger") == 0)
            {
                m_isAxisInUse = false;
            }
        }
    }

    void LogitechController(bool bRight)
    {
        if (!bRight)
        {
            if (Input.GetButtonDown("LogitechLeftTrigger"))
            {
                CreateCube();
            }
        }
        else
        {
            if (Input.GetButtonDown("LogitechRightTrigger"))
            {
                CreateCube();
            }
        }
    }

    void CreateCube()
    {
        if(canAttack)
        {
            canAttack = false;
            ps.Stop();
            Invoke("CanAttack", waitingTime);
            Instantiate(sc.cube, transform.position, Quaternion.identity);
        }
    }

    void CanAttack()
    {
        canAttack = true;
        ps.Play();
    }
}
