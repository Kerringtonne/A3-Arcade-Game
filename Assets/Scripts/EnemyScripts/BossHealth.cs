using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        healthText.text = "Health: " + currentHealth.ToString();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
