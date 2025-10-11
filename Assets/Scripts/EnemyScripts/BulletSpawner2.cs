using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletSpawner2 : MonoBehaviour
{
    enum SpawnerType { Spin, Spray, SlowSpin, QuickSpin }

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
            spawnedBullet = Instantiate (bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent <Bullet>().speed = bulletSpeed;
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

    void Start()
    {
        StartCoroutine(SwitchPattern());
    }

    IEnumerator SwitchPattern()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.SlowSpin;
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.Spray;
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.Spin;
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.SlowSpin;
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.Spray;

        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3 (0f, 0f, transform.eulerAngles.z + rotationSpeed * Time.deltaTime);
        if (spawnerType == SpawnerType.Spray) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + rotationSpeed * Time.deltaTime * -2);
        if (spawnerType == SpawnerType.SlowSpin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + rotationSpeed * Time.deltaTime * 0.3f);
        if (spawnerType == SpawnerType.QuickSpin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + rotationSpeed * Time.deltaTime * 5f);
        if (timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
    }
}
