using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float maxHP = 35f;
    [SerializeField] private float dropChance = 0.7f;
    [SerializeField] private GameObject[] upgradePrefabs;
    [SerializeField] private float damagePerHit = 10f;

    private float currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void Init(float hp, float chance, GameObject[] prefabs)
    {
        maxHP      = hp;
        currentHP  = hp;
        dropChance = chance;
        if (prefabs != null)
            upgradePrefabs = prefabs;
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0f)
            Die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Projectile>() != null)
            TakeDamage(damagePerHit);
    }

    private void Die()
    {
        if (Random.value <= dropChance && upgradePrefabs != null && upgradePrefabs.Length > 0)
        {
            int index = Random.Range(0, upgradePrefabs.Length);
            if (upgradePrefabs[index] != null)
                Instantiate(upgradePrefabs[index], transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
