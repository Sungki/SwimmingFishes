using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip Dash;
    public AudioClip Nest;
    public AudioClip DefenderScore;
    public AudioClip OffenderScore;
    public AudioClip Win;
    public AudioClip NestDestroyed;

    private void Awake()
    {
        Dash = Resources.Load<AudioClip>("SoundFX/sfx-DASH");
        Nest = Resources.Load<AudioClip>("SoundFX/sfx-PlaceDownNest");
        DefenderScore = Resources.Load<AudioClip>("SoundFX/sfx-Defensive-gain-score");
        OffenderScore = Resources.Load<AudioClip>("SoundFX/sfx-Offensive-gain-score");
        Win = Resources.Load<AudioClip>("SoundFX/sfx-Win");
        NestDestroyed = Resources.Load<AudioClip>("SoundFX/sfx-NestDesdroyed");
    }
}
