using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SceneState currentState = 0;
    private int scoreLeft = 0;
    private int scoreRight = 0;
    private AudioSource audioSource;

    public int countSupporter = 7;

    int totalTime = 60;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.5f;
    }

    void ReduceTime()
    {
        totalTime--;
        Toolbox.GetInstance().GetManager<DisplayManager>().textArray[1].text = totalTime.ToString();
        if (totalTime<=0)
        {
            audioSource.PlayOneShot(Toolbox.GetInstance().GetManager<AudioManager>().Win);
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void Init()
    {
        Cursor.visible = false;
        scoreLeft = 0;
        scoreRight = 0;
        currentState = SceneState.StartScreen;
        InvokeRepeating("ReduceTime", 1f, 1f);
    }

    public void NextScene()
    {
        if (currentState == SceneState.SummaryScreen) Init();
        else
        {
            currentState++;
        }
        SceneManager.LoadScene(currentState.ToString());
    }

    public void AddScoreLeft()
    {
        scoreLeft++;
        Toolbox.GetInstance().GetManager<DisplayManager>().textArray[0].text = scoreLeft.ToString();
        audioSource.PlayOneShot(Toolbox.GetInstance().GetManager<AudioManager>().DefenderScore);
    }

    public void AddScoreRight()
    {
        scoreRight++;
        Toolbox.GetInstance().GetManager<DisplayManager>().textArray[2].text = scoreRight.ToString();
        audioSource.PlayOneShot(Toolbox.GetInstance().GetManager<AudioManager>().OffenderScore);
    }

    void Update()
    {
        if (Input.GetKey("escape")) Application.Quit();
    }
}
