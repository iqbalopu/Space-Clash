using System.Collections;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private CountdownUI countdown;
    [SerializeField] private MatchResultUI matchResult;
    [SerializeField] private GameObject hudRoot;
    [SerializeField] private ShipController ship1Controller;
    [SerializeField] private ShipController ship2Controller;

    private void Start()
    {
        hudRoot.SetActive(false);
        ship1Controller.enabled = false;
        ship2Controller.enabled = false;

        StartCoroutine(countdown.PlayCountdown(OnCountdownComplete));
    }

    private void OnCountdownComplete()
    {
        hudRoot.SetActive(true);
        ship1Controller.enabled = true;
        ship2Controller.enabled = true;
    }
}
