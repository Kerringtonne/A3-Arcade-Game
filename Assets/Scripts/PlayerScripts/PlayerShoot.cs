using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public float bulletSpeed = 10f;
    public float lifetime = 1f;
    public float lifetime2 = 1f;
    public float fireRate = 1f;

    private float timer = 0f;

    // Wanted to work on the player shooting system more but couldn't figure it out...
    void BigShoot()
    {
        var proj = Instantiate(bulletPrefab, transform.position + Vector3.up * 0.4f, Quaternion.identity);
        proj.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * bulletSpeed;
        Destroy(proj, lifetime);
    }

    void NormalShoot()
    {
        var proj = Instantiate(bulletPrefab2, transform.position + Vector3.up * 0.4f, Quaternion.identity);
        proj.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * bulletSpeed * 0.5f;
        Destroy(proj, lifetime2);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            timer = 0f;
            NormalShoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BigShoot();
        }
    }
}
