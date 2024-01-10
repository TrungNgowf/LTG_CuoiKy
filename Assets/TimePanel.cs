using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{
    Timer timer;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindAnyObjectByType<Timer>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int minutes = Mathf.FloorToInt(timer.timerTime / 60);
        int seconds = Mathf.FloorToInt(timer.timerTime % 60);
        text.text = "Time\n" + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
