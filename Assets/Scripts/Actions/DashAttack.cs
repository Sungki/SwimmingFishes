using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    SelectControl sc;
    GameObject fish;
    private bool m_isAxisInUse = false;

    void Start()
    {

        sc = GetComponent<SelectControl>();

        fish = Instantiate(sc.prefab, transform.position, Quaternion.identity);
        fish.GetComponent<FollowTarget>().target = this.gameObject;
        fish.transform.localScale = new Vector3(sc.fishScale, sc.fishScale, sc.fishScale);

        if (tag == "LeftFish")
        {
            fish.GetComponent<Attack>().current = Attack.FishSide.LeftFish;
            fish.gameObject.tag = "LeftFish";
        }
        else
        {
            fish.GetComponent<Attack>().current = Attack.FishSide.RightFish;
            fish.gameObject.tag = "RightFish";
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

        if (Vector2.Distance(this.transform.position, fish.transform.position) < 0.3f)
        {
            fish.GetComponent<FollowTarget>().speed = 5f;
        }
    }

    void Keyboard()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PressAttack();
        }
    }

    void Mouse()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PressAttack();
        }
    }

    void XboxController(int num, bool bRight)
    {
        if (!bRight)
        {
            if (Input.GetAxisRaw("Xbox" + num + "LeftTrigger")!=0)
            {
                if (m_isAxisInUse == false)
                {
                    PressAttack();
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
            if (Input.GetAxisRaw("Xbox" + num + "RightTrigger")!=0)
            {
                if (m_isAxisInUse == false)
                {
                    PressAttack();
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
                PressAttack();
            }
        }
        else
        {
            if (Input.GetButtonDown("LogitechRightTrigger"))
            {
                PressAttack();
            }
        }
    }

    void PressAttack()
    {
        sc.dash = 20f;
        fish.GetComponent<FollowTarget>().speed = 10f;
        fish.GetComponent<FishState>().curr = FishObject.State.Attack;
    }
}
