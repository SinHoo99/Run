using System.Collections;
using UnityEngine;

public class Bullet : PoolObject
{
    public float speed = 5f;
    private Rigidbody2D _rb;
    private float _lifeTime = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rb.velocity = Vector2.left * speed;
        StartCoroutine(DisableAfterTime());
    }

    private void OnDisable()
    {
        _rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }

    public void Initialize(Vector2 position, Vector2 direction)
    {
        transform.position = position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
