using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(ShipLoadout))]
public class ShipController : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private Turret turret;

    private float thrustForce;
    private float rotateSpeed;
    private float maxSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        turret = GetComponent<Turret>();

        ShipLoadout loadout = GetComponent<ShipLoadout>();
        thrustForce = loadout.engine.thrustForce;
        rotateSpeed = loadout.engine.rotateSpeed;
        maxSpeed    = loadout.engine.maxSpeed;

        rb.gravityScale  = 0f;
        rb.linearDamping = 1.5f;
        rb.angularDamping = 3f;
    }

    private void FixedUpdate()
    {
        ShipInputData inputData = playerInput.InputData;

        if (inputData.thrust)
            rb.AddForce(transform.up * thrustForce);

        if (inputData.rotateLeft)
            rb.MoveRotation(rb.rotation + rotateSpeed * Time.fixedDeltaTime);

        if (inputData.rotateRight)
            rb.MoveRotation(rb.rotation - rotateSpeed * Time.fixedDeltaTime);

        if (inputData.fire && turret != null)
            turret.TryFire();

        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
    }
}
