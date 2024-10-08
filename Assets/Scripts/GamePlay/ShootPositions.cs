using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPositions : MonoBehaviour
{
    public float spawnInterval = 1f;
    [SerializeField] private PoolObject _bullet;
    [SerializeField] private ObjectPool _objectPool;
    

    private void Awake()
    {
        AddObjectPool();
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

            PoolObject bullet = _objectPool.SpawnFromPool("Bullet");

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
        _objectPool.AddObjectPool("Bullet", _bullet, 20); //::TODO 나중에 바꿀거임 예시
    }
}
