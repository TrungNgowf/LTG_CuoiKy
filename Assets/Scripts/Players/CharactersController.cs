using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersController : MonoBehaviour
{
    public GameObject huntress;
    public GameObject godOfWind;
    public GameObject godOfCrystal;
    public GameObject godOfFire;
    public GameObject godOfWater;
    public GameObject godOfEarth;
    public GameObject godOfMetal;
    private GameObject[] playersList;
    private int currentPlayer = 0;
    public GameObject timerCanvas;
    private Slider timer;
    [SerializeField] private float timeTransform = 30;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerCanvas.GetComponentInChildren<Slider>();
        playersList = new GameObject[7];
        playersList[0] = huntress;
        playersList[1] = godOfFire;
        playersList[2] = godOfCrystal;
        playersList[3] = godOfMetal;
        playersList[4] = godOfEarth;
        playersList[5] = godOfWater;
        playersList[6] = godOfWind;
        for (int i = 0; i < 7; i++)
        {
            if (i == 0) playersList[i].SetActive(true);
            else playersList[i].SetActive(false);
        }
        currentPlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerCanvas.activeInHierarchy)
        {
            timer.value -= Time.deltaTime;
            if (timer.value <= 0)
            {
                timer.value = 0;
                setPlayer(0);
            }
        }
        if (huntress.GetComponent<PlayerStats>().checkMaxMana())
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                setPlayer(1);
            };
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                setPlayer(2);
            };
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                setPlayer(3);
            };
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                setPlayer(4);
            };
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                setPlayer(5);
            };
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                setPlayer(6);
            };
        }

    }
    private void setPlayer(int choice)
    {
        for (int i = 0; i < 7; i++)
        {
            if (i == choice)
            {
                playersList[i].SetActive(true);
                playersList[i].GetComponent<PlayerStats>().setCurrentMana(0);
                playersList[currentPlayer].GetComponent<PlayerStats>().setCurrentMana(0);
                playersList[i].GetComponent<PlayerStats>().setCurrentHealth(playersList[currentPlayer].GetComponent<PlayerStats>().getCurrentHealth());
                if (choice != 0)
                    playersList[i].GetComponent<PlayerStats>().setVirtualHealth();
                playersList[i].transform.localPosition = playersList[currentPlayer].transform.localPosition;
                playersList[i].transform.localScale = playersList[currentPlayer].transform.localScale;
            }
            else playersList[i].SetActive(false);
        }
        if (choice != 0)
            setTimeTransform();
        else timerCanvas.SetActive(false);
        currentPlayer = choice;
    }
    private void setTimeTransform()
    {
        timerCanvas.SetActive(true);
        timer.maxValue = timeTransform;
        timer.minValue = 0;
        timer.value = timeTransform;
    }
}
