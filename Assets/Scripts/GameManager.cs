using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isPaused = false;
    public int pointsToWin = 1000;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (UI.instance.points >= pointsToWin)
        {
            Win();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseUnpauseMenu();
            }
        }
        
    }

    public void PauseUnpauseMenu()
    {
        isPaused = !isPaused;

        UI.instance.pauseMenu.SetActive(isPaused);

        Paused(isPaused);
    }

    public void Paused(bool isPaused)
    {
        if (isPaused == true)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Win()
    {
        isPaused = true;

        UI.instance.winScreen.SetActive(isPaused);

        Paused(isPaused);
    }

    public void Lose()
    {
        isPaused = true;

        UI.instance.loseScreen.SetActive(isPaused);

        Paused(isPaused);
    }
}
