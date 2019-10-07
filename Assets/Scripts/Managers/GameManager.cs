using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SceneState currentState = 0;
    private int score = 0;

    private void Start()
    {
        Cursor.visible = false;
        Init();
    }

    public void Init()
    {
        score = 0;
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

    public string GetScore() { return "Score: " + score.ToString(); }

    public void AddScore()
    {
        score++;
    }

    void Update()
    {
        if (Input.GetKey("escape")) Application.Quit();
    }
}
