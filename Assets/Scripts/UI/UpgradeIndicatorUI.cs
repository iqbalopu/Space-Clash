using UnityEngine;
using UnityEngine.UI;

public class UpgradeIndicatorUI : MonoBehaviour
{
    [SerializeField] private ShipUpgradeHandler targetShip;
    [SerializeField] private Image speedIcon;
    [SerializeField] private Image damageIcon;
    [SerializeField] private Image fireRateIcon;
    [SerializeField] private Color activeColor   = new Color(1f, 1f, 0f, 1f);
    [SerializeField] private Color inactiveColor = new Color(1f, 1f, 1f, 0.2f);

    private void Update()
    {
        if (targetShip == null) return;

        speedIcon.color    = targetShip.HasBoost(UpgradeType.SpeedBoost)    ? activeColor : inactiveColor;
        damageIcon.color   = targetShip.HasBoost(UpgradeType.DamageBoost)   ? activeColor : inactiveColor;
        fireRateIcon.color = targetShip.HasBoost(UpgradeType.FireRateBoost) ? activeColor : inactiveColor;
    }
}
