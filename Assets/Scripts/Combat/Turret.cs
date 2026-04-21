using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private string ownerTag;

    private float fireRate;
    private float projectileSpeed;
    private float damage;
    private float cooldownTimer;

    private void Start()
    {
        ShipLoadout loadout = GetComponent<ShipLoadout>();
        fireRate        = loadout.weapon.fireRate;
        projectileSpeed = loadout.weapon.projectileSpeed;
        damage          = loadout.weapon.damage;
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;
    }

    public void TryFire()
    {
        if (cooldownTimer > 0f)
            return;

        GameObject go = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile proj = go.GetComponent<Projectile>();
        proj.Init(projectileSpeed, damage, ownerTag);

        cooldownTimer = fireRate;
    }
}
