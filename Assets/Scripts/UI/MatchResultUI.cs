using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MatchResultUI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button rematchButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        panel.SetActive(false);

        rematchButton.onClick.AddListener(OnRematch);
        quitButton.onClick.AddListener(OnQuit);

        gameManager.onMatchOver.AddListener(ShowResult);
    }

    public void ShowResult(string winner)
    {
        Time.timeScale = 1f;
        panel.SetActive(true);
        resultText.text = winner;
    }

    private void OnRematch()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnQuit()
    {
        Application.Quit();
    }
}
