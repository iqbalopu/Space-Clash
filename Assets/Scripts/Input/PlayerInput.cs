using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Key thrustKey;
    [SerializeField] private Key rotateLeftKey;
    [SerializeField] private Key rotateRightKey;
    [SerializeField] private Key fireKey;

    public ShipInputData InputData { get; private set; }

    private void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        InputData = new ShipInputData
        {
            thrust      = kb[thrustKey].isPressed,
            rotateLeft  = kb[rotateLeftKey].isPressed,
            rotateRight = kb[rotateRightKey].isPressed,
            fire        = kb[fireKey].isPressed
        };
    }
}
