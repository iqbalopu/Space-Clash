using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float lifetime = 3f;

    private string ownerTag;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    public void Init(float spd, float dmg, string tag)
    {
        speed    = spd;
        damage   = dmg;
        ownerTag = tag;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ownerTag))
            return;

        HealthComponent health = other.GetComponent<HealthComponent>();
        if (health != null)
            health.TakeDamage(damage);

        Destroy(gameObject);
    }
}
