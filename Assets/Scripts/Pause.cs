using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool isPaused = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else { PauseGame(); }
        }
        
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void EnlargeSize()
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
    }

    public void ResumeSize()
    {
        transform.localScale = new Vector2(1.0f, 1.0f);
    }
}
