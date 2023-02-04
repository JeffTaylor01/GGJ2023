using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool isPaused = false;

    private void Start()
    {
        Time.timeScale = 0;
    }
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

    public void ResumeGame()
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

    public void TimeScaleResume()
    {
        Time.timeScale = 1;
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        Time.timeScale = 1;
    }
}
