using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        playersList = new GameObject[7];
        playersList[0] = huntress;
        playersList[1] = godOfFire;
        playersList[2] = godOfCrystal;
        playersList[3] = godOfMetal;
        playersList[4] = godOfEarth;
        playersList[5] = godOfWater;
        playersList[6] = godOfWind;
        for(int i = 0; i < 7; i++)
        {
            if(i==0) playersList[i].SetActive(true);
            else playersList[i].SetActive(false);
        }
        currentPlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
            if (i == choice) { 
                playersList[i].SetActive(true);
                playersList[i].GetComponent<PlayerStats>().setCurrentHealth(playersList[currentPlayer].GetComponent<PlayerStats>().getCurrentHealth());
                playersList[i].GetComponent<PlayerStats>().setVirtualHealth();
                playersList[i].transform.localPosition = playersList[currentPlayer].transform.localPosition;
                playersList[i].transform.localScale = playersList[currentPlayer].transform.localScale;
            }
            else playersList[i].SetActive(false);
        }
        currentPlayer = choice;
    }
}
