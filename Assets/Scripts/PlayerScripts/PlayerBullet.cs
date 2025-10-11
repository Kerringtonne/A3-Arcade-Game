using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss")
        {
            var healthComponent = collision.GetComponent<BossHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}
