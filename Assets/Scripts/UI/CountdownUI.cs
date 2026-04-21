using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;

    [SerializeField] private float punchScale   = 1.5f;
    [SerializeField] private float shrinkTime   = 0.35f;

    public IEnumerator PlayCountdown(Action onComplete)
    {
        yield return StartCoroutine(ShowBeat("3",     1.0f, punchScale));
        yield return StartCoroutine(ShowBeat("2",     1.0f, punchScale));
        yield return StartCoroutine(ShowBeat("1",     1.0f, punchScale));
        yield return StartCoroutine(ShowBeat("FIGHT!", 0.6f, punchScale * 1.2f));

        countdownText.gameObject.SetActive(false);
        onComplete?.Invoke();
    }

    private IEnumerator ShowBeat(string label, float holdTime, float startScale)
    {
        countdownText.gameObject.SetActive(true);
        countdownText.text = label;
        countdownText.transform.localScale = Vector3.one * startScale;

        float elapsed = 0f;
        while (elapsed < shrinkTime)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / shrinkTime;
            float scale = Mathf.Lerp(startScale, 1f, t);
            countdownText.transform.localScale = Vector3.one * scale;
            yield return null;
        }

        countdownText.transform.localScale = Vector3.one;

        float remaining = holdTime - shrinkTime;
        if (remaining > 0f)
            yield return new WaitForSecondsRealtime(remaining);
    }
}
