using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    TextMeshProUGUI text;
    ScoreManager scoreManager;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score\n" + scoreManager.score;
    }
}
