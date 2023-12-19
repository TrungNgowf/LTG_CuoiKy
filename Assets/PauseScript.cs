using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject lossPanel;
    [SerializeField] GameObject wonPanel;
    [SerializeField] GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }
    public void OpenMenu()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void goHome()
    {
        if (wonPanel.activeSelf)
        {
            wonPanel.SetActive(false);
        }
        SceneManager.LoadScene("Home");
        Time.timeScale = 1f;
    }

    public void saveGame()
    {
        Time.timeScale = 1f;
    }

    public void continueGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void showLossPanel()
    {
        StartCoroutine(ShowLossPanelCoroutine());
    }

    private IEnumerator ShowLossPanelCoroutine()
    {
        Time.timeScale = 0f;
        lossPanel.SetActive(true);

        // Chờ 2 giây
        yield return new WaitForSeconds(2f);

        // Thực hiện các hành động sau khi chờ 2 giây
        Time.timeScale = 1f;
        lossPanel.SetActive(false);
        SceneManager.LoadScene("Level_01");
    }

    public void showWonPanel()
    {
        Time.timeScale = 0f;
        wonPanel.SetActive(true);
    }
}
