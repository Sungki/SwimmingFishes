using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKeyboard : MonoBehaviour
{
    public GameObject[] fish;
    FollowTarget[] ft;

    private void Start()
    {
        ft = new FollowTarget[5];
        for(int i =0; i<5; i++)
        {
            ft[i] = fish[i].GetComponent<FollowTarget>();
        }
    }

    void Update()
    {
        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) move += Vector3.left;
        if (Input.GetKey(KeyCode.D)) move += Vector3.right;
        if (Input.GetKey(KeyCode.W)) move += Vector3.up;
        if (Input.GetKey(KeyCode.S)) move += Vector3.down;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            move += move * 20f;
            foreach (FollowTarget f in ft)
                f.speed = 10;
        }

        for (int i = 0; i < 5; i++)
        {
            if (Vector2.Distance(this.transform.position, fish[i].transform.position) < 0.2f) ft[i].speed = 2f;
        }

        transform.position += move * 8f * Time.deltaTime;
    }
}
