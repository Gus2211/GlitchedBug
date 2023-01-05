using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject leaveMenuUI;

    private void Awake() 
    {
        ResumeGame();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                LeaveGame();
            }
        }
    }


    public void ResumeGame()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        leaveMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }
    void LeaveGame()
    {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            leaveMenuUI.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
    }
}
