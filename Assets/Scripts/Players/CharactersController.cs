using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersController : MonoBehaviour
{
    public GameObject huntress;
    public GameObject godOfWind;
    public GameObject godOfCrystal;
    // Start is called before the first frame update
    void Start()
    {
        huntress.SetActive(true);
        godOfWind.SetActive(false);
        godOfCrystal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            huntress.SetActive(false);
            godOfWind.SetActive(true);
            godOfWind.transform.localPosition = huntress.transform.localPosition;
        };
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            huntress.SetActive(true);
            godOfWind.SetActive(false);
            huntress.transform.localPosition = godOfWind.transform.localPosition;
        };
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            huntress.SetActive(false);
            godOfCrystal.SetActive(true);
            godOfCrystal.transform.localPosition = huntress.transform.localPosition;
        };
    }
}
