using System.Collections;
using UnityEngine;

public class Bullet : PoolObject
{
    public float speed = 5f;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    [SerializeField] private Sprite[] sprites;
    private float _lifeTime = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        _rb.velocity = Vector2.down * speed;
        SetRandomSprite();
        UpdateColliderSize();
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

    private void UpdateColliderSize()
    {
        if (_spriteRenderer != null && _boxCollider != null && _spriteRenderer.sprite != null)
        {
            _boxCollider.size = _spriteRenderer.bounds.size;
            _boxCollider.offset = _spriteRenderer.bounds.center;
        }
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
        transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    private void SetRandomSprite()
    {
        if(sprites.Length > 0)
        {
            int randomIndex = Random.Range(0, sprites.Length);
            _spriteRenderer.sprite = sprites[randomIndex]; 
        }
    }
}
