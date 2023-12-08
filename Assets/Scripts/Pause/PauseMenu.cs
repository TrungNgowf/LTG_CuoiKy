using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isPaused;
    private bool isMuted = false;
    private void Start()
    {
        // Ensure the pause menu is initially hidden
        ContinueGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle pause state on Escape key press
            if (Time.timeScale == 0f)
                ContinueGame();
            else
                PauseGame();
        }
    }

    public void ContinueGame()
    {
        // Hide the pause menu and resume time
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void PauseGame()
    {
        // Show the pause menu and pause time
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void RestartGame()
    {
        // Implement the logic to restart the game
        // For example, you can reload the current scene
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        // Implement the logic to quit the game
        // For example, you can use Application.Quit() in standalone builds
        // or UnityEditor.EditorApplication.isPlaying = false; in the editor
        // Implement the logic to quit the game
        // For standalone builds
        #if UNITY_STANDALONE
                        Application.Quit();
        #endif

                // For the editor
        #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
    }


}
