using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPositions : MonoBehaviour
{
    public float spawnInterval = 1f;
    private float intervalDecreaseRate = 0.1f;
    private float minSpawnInterval = 0.5f;
    private float timeToDecrease = 5f;
    [SerializeField] private PoolObject _bullet;
    [SerializeField] private ObjectPool _objectPool;
    
    private void Start()
    {
        AddObjectPool();
        StartCoroutine(SpawnBullets());
        StartCoroutine(DecreaseSpawnInterval());
    }

    IEnumerator SpawnBullets()
    {
        while (true)
        {
            float randomXPosition = Random.Range(-2, 2);
            Vector3 spawnPosition = new Vector3(randomXPosition, transform.position.y, 0);
            Vector2 direction = Vector2.down;

            CreatBullet("Bullet", spawnPosition, direction);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator DecreaseSpawnInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToDecrease);
            spawnInterval = Mathf.Max(spawnInterval - intervalDecreaseRate, minSpawnInterval);
        }
    }
    public void AddObjectPool()
    {
        _objectPool.AddObjectPool("Bullet", _bullet, 100); //::TODO 나중에 바꿀거임 예시
    }

    private void CreatBullet(string tag, Vector2 position, Vector2 direction)
    {
        PoolObject bullet = _objectPool?.SpawnFromPool(tag);

        if (bullet == null)
        {
            Debug.LogError("Failed to spawn bullet from pool!");
            return;
        }

        bullet.ReturnMyComponent<Bullet>().Initialize(position, direction);
    }
}
