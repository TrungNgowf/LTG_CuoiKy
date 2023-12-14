using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
