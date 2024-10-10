using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPositions : MonoBehaviour
{
    public float spawnInterval = 1f;
    [SerializeField] private PoolObject _bullet;
    [SerializeField] private ObjectPool _objectPool;
    
    private void Start()
    {
        AddObjectPool();
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        while (true)
        {
            float randomYPosition = Random.Range(-6, 6);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomYPosition, 0);
            Vector2 direction = Vector2.left;

            CreatBullet("Bullet", spawnPosition, direction);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void AddObjectPool()
    {
        _objectPool.AddObjectPool("Bullet", _bullet, 20); //::TODO 나중에 바꿀거임 예시
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
