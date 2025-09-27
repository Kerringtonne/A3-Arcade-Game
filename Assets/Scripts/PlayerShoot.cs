using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float lifetime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var proj = Instantiate(bulletPrefab, transform.position + Vector3.up * 0.4f, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * bulletSpeed;
            Destroy(proj, lifetime);
        }
    }
}
