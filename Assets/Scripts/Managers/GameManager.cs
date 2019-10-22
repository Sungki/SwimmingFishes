using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SceneState currentState = 0;
    private int scoreLeft = 0;
    private int scoreRight = 0;

    int totalTime = 60;

    void ReduceTime()
    {
        totalTime--;
        Toolbox.GetInstance().GetManager<DisplayManager>().textArray[1].text = totalTime.ToString();
        if (totalTime<=0)
        {
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
    }

    public void AddScoreRight()
    {
        scoreRight++;
        Toolbox.GetInstance().GetManager<DisplayManager>().textArray[2].text = scoreRight.ToString();
    }

    void Update()
    {
        if (Input.GetKey("escape")) Application.Quit();
    }
}
