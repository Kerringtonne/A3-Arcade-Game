using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public string sceneName = "Scene";

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    void Update()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }
}
