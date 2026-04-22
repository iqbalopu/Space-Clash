using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class UpgradePickup : MonoBehaviour
{
    [SerializeField] private UpgradeType upgradeType;
    [SerializeField] private float boostDuration = 8f;
    [SerializeField] private float autoExpireTime = 10f;

    private void Start()
    {
        Destroy(gameObject, autoExpireTime);

        CircleCollider2D col = GetComponent<CircleCollider2D>();
        col.isTrigger = true;
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, 90f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player1") && !other.CompareTag("Player2"))
            return;

        ShipUpgradeHandler handler = other.GetComponent<ShipUpgradeHandler>();
        if (handler != null)
        {
            handler.ApplyBoost(upgradeType, boostDuration);
            Destroy(gameObject);
        }
    }
}
