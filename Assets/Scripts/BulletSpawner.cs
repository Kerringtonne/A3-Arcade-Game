using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletSpeed = 1f;
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
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3 (0f, 0f, transform.eulerAngles.z + rotationSpeed * Time.deltaTime);
        if (timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
    }
}
