using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceHP : MonoBehaviour
{
    private AudioSource audioSource;
    public int hp = 0;

    public bool isSupporter = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Hit()
    {
        hp--;
        if (hp <= 0)
        {
            if (this.gameObject.tag == "Nest")
            {
                if (audioSource) audioSource.Play();
            }

            if (isSupporter) Toolbox.GetInstance().GetManager<GameManager>().countSupporter--;

            Destroy(this.gameObject, 0.4f);
        }
    }
}
