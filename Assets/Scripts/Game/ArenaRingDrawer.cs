using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ArenaRingDrawer : MonoBehaviour
{
    [SerializeField] float radius = 12f;
    [SerializeField] int segments = 64;

    void Start()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.positionCount = segments + 1;
        lr.loop = true;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * 2 * Mathf.PI / segments;
            lr.SetPosition(i, new Vector3(
                Mathf.Cos(angle) * radius,
                Mathf.Sin(angle) * radius, 0));
        }
    }
}