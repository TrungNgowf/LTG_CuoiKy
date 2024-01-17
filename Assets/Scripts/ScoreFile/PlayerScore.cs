using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerScore
{
    public string Name;
    public int Score;
    public float Time;

    public PlayerScore(string name, int score, float time)
    {
        Name = name;
        Score = score;
        Time = time;
    }

    public PlayerScore()
    {
    }
}
