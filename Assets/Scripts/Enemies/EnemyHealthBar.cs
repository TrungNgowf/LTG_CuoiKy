using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {

    }
    public void initHealthBar(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void updateHealthBar(float currentHealth)
    {
        slider.value = currentHealth;
    }
}
