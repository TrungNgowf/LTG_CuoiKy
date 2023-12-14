using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeCript : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level_01");
    }
}
