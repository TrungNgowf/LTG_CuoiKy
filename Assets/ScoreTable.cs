using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{
    List<PlayerScore> playerScores = new List<PlayerScore>();
    private string fileName = "hi-score.json";
    [SerializeField] int maxCount = 10;
    [SerializeField] GameObject scoreRowPrefab;
    [SerializeField] Transform scoreTable;
    List<GameObject> scoreUIList = new List<GameObject>();
    void Start()
    {
        LoadHightScore();
        UpdateUI(playerScores);
    }

    void Update()
    {
        
    }

    private void LoadHightScore()
    {
        playerScores = FileHandler.ReadListFromJSON<PlayerScore>(fileName);
        playerScores = playerScores.OrderByDescending(o => o.Score).ThenByDescending(o => o.Time).ToList();
        while (playerScores.Count > maxCount)
        {
            playerScores.RemoveAt(maxCount);
        }
    }
    private void UpdateUI(List<PlayerScore> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            PlayerScore playerScore = list[i];
            var inst = Instantiate(scoreRowPrefab, Vector3.zero, Quaternion.identity);
            inst.transform.SetParent(scoreTable);
            scoreUIList.Add(inst);
            var texts = scoreUIList[i].GetComponentsInChildren<Text>();
            texts[0].text = (i+1).ToString();
            texts[1].text = playerScore.Name;
            texts[2].text = playerScore.Score.ToString();
            int minutes = Mathf.FloorToInt(playerScore.Time / 60);
            int seconds = Mathf.FloorToInt(playerScore.Time % 60);
            texts[3].text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    public void GoToHomeScreen()
    {
        SceneManager.LoadScene("Home");
    }
}
