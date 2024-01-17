using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField inputName;
    private string fileName = "hi-score.json";
    List<PlayerScore> listScore = new List<PlayerScore>();

    private void Start()
    {
        listScore = FileHandler.ReadListFromJSON<PlayerScore>(fileName);
    }
    public void AddNewScore()
    {
        ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
        Timer timer = FindAnyObjectByType<Timer>();
        PlayerScore score = new PlayerScore(inputName.text == "" ? "Unknown" : inputName.text, scoreManager.score, timer.timerTime);
        listScore.Add(score);
        FileHandler.SaveToJSON<PlayerScore>(listScore, fileName);
        inputName.text = "";
        GoHomeScreen();
    }
    private void GoHomeScreen()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1f;
    }
}
