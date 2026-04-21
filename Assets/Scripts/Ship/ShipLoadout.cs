using System;
using UnityEngine;

public class ShipLoadout : MonoBehaviour
{
    [Serializable]
    public class HullData
    {
        public string hullName;
        public float maxHP;
        public float shipScale;
    }

    [Serializable]
    public class WeaponData
    {
        public string weaponName;
        public float damage;
        public float fireRate;
        public float projectileSpeed;
    }

    [Serializable]
    public class EngineData
    {
        public string engineName;
        public float thrustForce;
        public float rotateSpeed;
        public float maxSpeed;
    }

    [SerializeField] public HullData hull;
    [SerializeField] public WeaponData weapon;
    [SerializeField] public EngineData engine;
}
