using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform ship1;
    [SerializeField] private Transform ship2;

    private void LateUpdate()
    {
        if (ship1 == null || ship2 == null)
            return;

        Vector3 midpoint = (ship1.position + ship2.position) * 0.5f;
        midpoint.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, midpoint, 5f * Time.deltaTime);
    }
}
