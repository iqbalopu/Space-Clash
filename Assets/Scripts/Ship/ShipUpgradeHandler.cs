using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUpgradeHandler : MonoBehaviour
{
    [SerializeField] private ShipLoadout loadout;
    [SerializeField] private ShipController shipController;

    private float originalMaxSpeed;
    private float originalDamage;
    private float originalFireRate;

    private Dictionary<UpgradeType, Coroutine> activeBoosts;

    private void Start()
    {
        activeBoosts = new Dictionary<UpgradeType, Coroutine>();

        originalMaxSpeed = loadout.engine.maxSpeed;
        originalDamage   = loadout.weapon.damage;
        originalFireRate = loadout.weapon.fireRate;
    }

    public void ApplyBoost(UpgradeType type, float duration)
    {
        if (activeBoosts.ContainsKey(type))
        {
            StopCoroutine(activeBoosts[type]);
            activeBoosts.Remove(type);
        }

        Coroutine c = StartCoroutine(RunBoost(type, duration));
        activeBoosts[type] = c;
    }

    private IEnumerator RunBoost(UpgradeType type, float duration)
    {
        switch (type)
        {
            case UpgradeType.SpeedBoost:
                loadout.engine.maxSpeed = originalMaxSpeed * 1.5f;
                shipController.RefreshStats();
                yield return new WaitForSeconds(duration);
                loadout.engine.maxSpeed = originalMaxSpeed;
                shipController.RefreshStats();
                break;

            case UpgradeType.DamageBoost:
                loadout.weapon.damage = originalDamage * 2f;
                yield return new WaitForSeconds(duration);
                loadout.weapon.damage = originalDamage;
                break;

            case UpgradeType.FireRateBoost:
                loadout.weapon.fireRate = originalFireRate * 0.5f;
                yield return new WaitForSeconds(duration);
                loadout.weapon.fireRate = originalFireRate;
                break;
        }

        activeBoosts.Remove(type);
    }

    public bool HasBoost(UpgradeType type)
    {
        return activeBoosts.ContainsKey(type);
    }

    public float GetBoostTimeRemaining(UpgradeType type)
    {
        return activeBoosts.ContainsKey(type) ? 8f : 0f;
    }
}
