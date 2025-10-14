using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public LoadScene loadSceneScript;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer2;
    public Color32 hitColour = new(48, 236, 255, 255);
    public float hitSeconds = 1;

    private Color originalColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        StartCoroutine(BossHit());

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        healthText.text = "Health: " + currentHealth.ToString();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            if (loadSceneScript != null)
            {
                loadSceneScript.GoToScene();
            }
        }
    }

    public IEnumerator BossHit()
    {
        if (currentHealth < maxHealth)
        {
            spriteRenderer.color = hitColour;
            spriteRenderer2.color = hitColour;
            yield return new WaitForSeconds(hitSeconds);
            spriteRenderer.color = originalColor;
            spriteRenderer2.color = originalColor;
        }
    }
}
