using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPositions : MonoBehaviour
{
    private ObjectPool objectPool;
    public float spawnInterval = 1f;

    private void Awake()
    {
        
    }
    private void Start()
    {
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        while (true)
        {
            float randomYPosition = Random.Range(-6, 6);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomYPosition, 0);

            PoolObject bullet = objectPool.SpawnFromPool("Bullet");

            if (bullet != null)
            {
                bullet.transform.position = spawnPosition;
                bullet.transform.rotation = Quaternion.identity;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void AddObjectPool()
    {
        objectPool.AddObjectPool()
    }

    private void CreatBullet(string tag, Vector2 position, Vector2 direction)
    {
        PoolObject bullet = objectPool?.SpawnFromPool(tag);

        bullet.ReturnMyComponent<Bullet>().Initialize(position, direction);
    }
}
