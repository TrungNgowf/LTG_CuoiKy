using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public float maxHealth = 500;
    [SerializeField] public float attackDamage = 20;
    [SerializeField] public float attackSpeed = 1.2f;
    [SerializeField] public float speedRun = 2;
    [SerializeField] public float jumpForce = 4;
    [SerializeField] public float armor = 5;
    [SerializeField] public int scoreAmount = 10;
    PauseScript pauseScript;
    [SerializeField] public Slider healthBar;
    float currentHealth;
    public GameObject[] dropItems;
    ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<Slider>();
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        pauseScript = FindAnyObjectByType<PauseScript>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            currentHealth = -1;
            Dead();
        }
    }
    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            float finalDamage = damage - armor;
            currentHealth -= finalDamage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthBar.value = currentHealth;
            UpdateColorHealthBar();
            animator.SetTrigger("Hitted");
        }
        if(gameObject.name == "BringerOfDeath")
        {
            DropItemsOnBoss();
        }
    }
    private async void Dead()
    {
        gameObject.GetComponent<EnemyStats>().enabled = false;
        animator.SetBool("IsDead", true);
        if(maxHealth >= 2000)
        {
            pauseScript.showWonPanel();
        }
        scoreManager.GainScore(scoreAmount);
        DropItems();
        await Task.Delay(1000);
        gameObject.SetActive(false);
    }
    private void UpdateColorHealthBar()
    {
        Image[] fillColor = healthBar.GetComponentsInChildren<Image>();
        if (currentHealth / maxHealth <= 0.25)
        {
            fillColor[1].color = Color.red;
        }
        else if (currentHealth / maxHealth <= 0.5)
        {
            fillColor[1].color = Color.yellow;
        }
        else if (currentHealth / maxHealth <= 0.75)
        {
            fillColor[1].color = Color.blue;
        }
        else
        {
            fillColor[1].color = Color.green;
        }
    }
    private void DropItems()
    {
        int randomNumber = Random.Range(1, 101);
        for (int i = 0; i < dropItems.Length; i++)
        {
            if (dropItems[i].name == "ManaGem")
            {
                if(randomNumber <= 100) Instantiate(dropItems[i], transform.position, Quaternion.identity);
            }
            else if(dropItems[i].name == "HeartGem")
            {
                if(randomNumber <= 30) Instantiate(dropItems[i], transform.position, Quaternion.identity);
            }
        }
    }
    private void DropItemsOnBoss()
    {
        int randomNumber = Random.Range(1, 101);
        for (int i = 0; i < dropItems.Length; i++)
        {
            if (dropItems[i].name == "ManaGem")
            {
                if (randomNumber <= 50) Instantiate(dropItems[i], transform.position, Quaternion.identity);
            }
            else if (dropItems[i].name == "HeartGem")
            {
                if (randomNumber <= 10) Instantiate(dropItems[i], transform.position, Quaternion.identity);
            }
        }
    }
}
