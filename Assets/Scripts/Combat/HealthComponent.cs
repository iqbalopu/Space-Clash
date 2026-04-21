using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHP = 100f;

    public float CurrentHP { get; private set; }

    public UnityEvent onDeath;

    private void Start()
    {
        CurrentHP = maxHP;
    }

    public void SetMaxHP(float value)
    {
        maxHP = value;
        CurrentHP = maxHP;
    }

    public void TakeDamage(float amount)
    {
        CurrentHP = Mathf.Clamp(CurrentHP - amount, 0f, maxHP);
        if (CurrentHP <= 0f)
            onDeath.Invoke();
    }

    public float GetPercent()
    {
        return CurrentHP / maxHP;
    }
}
