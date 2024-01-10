using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    float timerTime;
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        timerTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timerTime / 60);
        int seconds = Mathf.FloorToInt(timerTime % 60);
        timerText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes,seconds);
    }
}
