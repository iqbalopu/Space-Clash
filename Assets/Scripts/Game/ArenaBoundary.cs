using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArenaBoundary : MonoBehaviour
{
    [SerializeField] private float arenaRadius = 12f;
    [SerializeField] private float pushForce = 30f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (transform.position.magnitude > arenaRadius)
        {
            Vector2 inward = -((Vector2)transform.position).normalized;
            rb.AddForce(inward * pushForce);
        }
    }
}
