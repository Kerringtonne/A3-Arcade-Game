using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float rotation = 0f;
    public float speed = 1f;

    private Vector2 spawnPoint;
    private float timer = 0f;

    private Vector2 Movement(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x+spawnPoint.x, y+spawnPoint.y);
    }

    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    // Decreases player health when hit by bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<PlayerHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
                Destroy(gameObject);
            }
        }

        if (collision.tag == "DestroyZone")
        {
            Destroy(gameObject);
        }
    }

}
