using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void Continue()
    {
        SceneManager.LoadScene("Level_01");
    }
}
