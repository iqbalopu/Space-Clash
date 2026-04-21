using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBarUI : MonoBehaviour
{
    [SerializeField] private HealthComponent target;
    [SerializeField] private Image fillImage;
    [SerializeField] private TextMeshProUGUI hpText;

    private static readonly Color ColorGreen  = new Color(0.2f, 0.85f, 0.2f);
    private static readonly Color ColorYellow = new Color(1f, 0.85f, 0f);
    private static readonly Color ColorRed    = new Color(0.9f, 0.1f, 0.1f);

    [SerializeField] private float colorLerpSpeed = 8f;

    private Color currentDisplayColor;

    private void Start()
    {
        currentDisplayColor = ColorGreen;
        if (fillImage != null)
            fillImage.color = currentDisplayColor;
    }

    private void Update()
    {
        if (target == null) return;

        float pct = target.GetPercent();

        if (fillImage != null)
            fillImage.fillAmount = pct;

        if (hpText != null)
            hpText.text = Mathf.CeilToInt(target.CurrentHP).ToString();

        Color targetColor;
        if (pct > 0.6f)
            targetColor = ColorGreen;
        else if (pct > 0.3f)
            targetColor = ColorYellow;
        else
            targetColor = ColorRed;

        currentDisplayColor = Color.Lerp(currentDisplayColor, targetColor, Time.deltaTime * colorLerpSpeed);

        if (fillImage != null)
            fillImage.color = currentDisplayColor;
    }
}
