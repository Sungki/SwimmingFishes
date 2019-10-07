using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
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

    [SerializeField] Control current = 0;

    public GameObject[] fish;
    FollowTarget[] ft;
//    MovePointer mv;
    SelectControl sc;
    FishState[] fs;
    //    Rigidbody2D[] rb;

    private bool m_isAxisInUse = false;

    void Start()
    {
//        mv = GetComponent<MovePointer>();
        sc = GetComponent<SelectControl>();

        ft = new FollowTarget[fish.Length];
        fs = new FishState[fish.Length];
        //        rb = new Rigidbody2D[5];
        for (int i = 0; i < fish.Length; i++)
        {
//            rb[i] = fish[i].GetComponent<Rigidbody2D>();
            ft[i] = fish[i].GetComponent<FollowTarget>();
            fs[i] = fish[i].GetComponent<FishState>();
        }
    }

    void Update()
    {
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
                LogitechController(false);
                break;
            case Control.LogitechController_Right:
                LogitechController(true);
                break;
            case Control.AI:
                break;
        }

        for (int i = 0; i < fish.Length; i++)
        {
            if (Vector2.Distance(this.transform.position, fish[i].transform.position) < 0.3f)
            {
                  ft[i].speed = 5f;
//                rb[i].AddForce(Vector2.zero);
            }
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
        /*            for (int i = 0; i < 5; i++)
                    {
                        rb[i].AddForce(ft[i].velocity*500f);
                    }*/

        foreach (FollowTarget f in ft)
        {
            f.speed = 10f;
        }

        foreach (FishState f in fs)
        {
            f.curr = FishObject.State.Attack;
        }

    }
}
