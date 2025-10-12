using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Retry");
        }
    }

    void Update()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }
}
