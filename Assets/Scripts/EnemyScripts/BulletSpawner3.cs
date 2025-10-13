using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletSpawner3 : MonoBehaviour
{
    enum SpawnerType { Spin, Spray, SlowSpin, SlowerSpin }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletSpeed = 1f;
    public float rotationSpeed = 90f; // rotation degree per second
    public int bulletCount = 2;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 0.1f;

    private GameObject spawnedBullet;
    private float timer = 0f;
    private void Fire()
    {
        for (int i = 1; i <= bulletCount; i++)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = bulletSpeed;
            spawnedBullet.transform.rotation = transform.rotation * Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + i * 360 / bulletCount);
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
            bulletCount = 1;
            firingRate = 0.05f;
            rotationSpeed = 200;
            bulletSpeed = 1;
            spawnerType = SpawnerType.Spin;
            yield return new WaitForSeconds(10);
            firingRate = 0.1f;
            bulletCount = 3;
            bulletSpeed = 2;
            rotationSpeed = 90;
            spawnerType = SpawnerType.Spray;
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.Spin;
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.SlowSpin;
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.Spin;
            yield return new WaitForSeconds(10);
            bulletCount = 3;
            firingRate = 0.2f;
            bulletSpeed = 3;
            rotationSpeed = 200;
            spawnerType = SpawnerType.Spin;
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.Spray;
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.Spin;
            yield return new WaitForSeconds(10);
            spawnerType = SpawnerType.SlowSpin;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + rotationSpeed * Time.deltaTime);
        if (spawnerType == SpawnerType.Spray) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + rotationSpeed * Time.deltaTime * -2);
        if (spawnerType == SpawnerType.SlowSpin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + rotationSpeed * Time.deltaTime * 0.7f);
        if (spawnerType == SpawnerType.SlowerSpin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + rotationSpeed * Time.deltaTime * 0.1f);

        if (timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
    }
}
