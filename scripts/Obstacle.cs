using UnityEngine;

public class ObstaculerController : MonoBehaviour
{
    [SerializeField] private float minSize = 0.3f;
    [SerializeField] private float maxSize = 2f;
    [SerializeField] private float minForce = 3f;
    [SerializeField] private float maxForce = 8f;
    [SerializeField] private float minTorque = 10f;
    [SerializeField] private float maxTorque = 20f;

    void Start()
    {
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size, size, 1);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.mass = size * 2;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float force = Random.Range(minForce, maxForce);
        rb.AddForce(randomDirection * force, ForceMode2D.Impulse);

        float torque = Random.Range(minTorque, maxTorque);
        rb.AddTorque(torque, ForceMode2D.Impulse);
    }
}