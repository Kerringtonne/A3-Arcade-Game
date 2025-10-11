using UnityEngine;

public class BulletSpawnerSecondary : MonoBehaviour
{
    enum SpawnerType { Spin }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletSpeed = 1f;
    public GameObject bullet2;
    public float bulletSpeed2 = 2f;
    public float rotationSpeed = 90f; // rotation degree per second

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;
    private void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = bulletSpeed;
            spawnedBullet.transform.rotation = transform.rotation;

            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = -bulletSpeed;
            spawnedBullet.transform.rotation = transform.rotation;
        }

        if (bullet2)
        {
            spawnedBullet = Instantiate(bullet2, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = bulletSpeed2 * 0.8f;
            spawnedBullet.transform.rotation = transform.rotation * Quaternion.Euler(0f, 0f, 90f);

            spawnedBullet = Instantiate(bullet2, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = -bulletSpeed2 * 0.8f;
            spawnedBullet.transform.rotation = transform.rotation * Quaternion.Euler(0f, 0f, 90f);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
    }
}
