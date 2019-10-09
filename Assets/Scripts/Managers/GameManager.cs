using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SceneState currentState = 0;
    private int scoreLeft = 0;
    private int scoreRight = 0;

    private void Start()
    {
        Cursor.visible = false;
        Init();
    }

    public void Init()
    {
        scoreLeft = 0;
        scoreRight = 0;
        currentState = SceneState.StartScreen;
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
        DisplayManager.ShowHUDLeft(scoreLeft.ToString());
    }

    public void AddScoreRight()
    {
        scoreRight++;
        DisplayManager.ShowHUDRight(scoreRight.ToString());
    }

    void Update()
    {
        if (Input.GetKey("escape")) Application.Quit();
    }
}
