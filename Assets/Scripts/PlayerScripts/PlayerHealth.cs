using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public string sceneName = "Scene";
    public SpriteRenderer spriteRenderer;
    public Color32 hitColour = new(48, 236, 255, 255);
    public float hitSeconds = 1;

    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        StartCoroutine(PlayerHit());

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public IEnumerator PlayerHit()
    {
        if (currentHealth < maxHealth)
        {
            spriteRenderer.color = hitColour;
            yield return new WaitForSeconds(hitSeconds);
            spriteRenderer.color = originalColor;
        }
    }

    void Update()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }
}
