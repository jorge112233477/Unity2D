using UnityEngine;

public class ObstaculerController : MonoBehaviour
{
    [SerializeField] private float minSize = 0.3f;
    [SerializeField] private float maxSize = 2f;
    [SerializeField] private float minForce = 3f;
    [SerializeField] private float maxForce = 8f;
    [SerializeField] private float minTorque = 10f;
    [SerializeField] private float maxTorque = 20f;

    [SerializeField] private GameObject impactEffectPrefab;
    [SerializeField] private float effectDuration = 0.5f;   // cuánto dura el efecto
    [SerializeField] private float effectCooldown = 0.15f;  // tiempo mínimo entre efectos de ESTA rana

    private float lastEffectTime = -999f;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (impactEffectPrefab == null) return;

        // Si esta rana sacó un efecto hace muy poco, no saca otro
        if (Time.time - lastEffectTime < effectCooldown) return;

        lastEffectTime = Time.time;

        // Si choca con otra rana, le avisamos para que ella no cree otro efecto
        ObstaculerController otra = collision.gameObject.GetComponent<ObstaculerController>();
        if (otra != null)
        {
            otra.lastEffectTime = Time.time;
        }

        ContactPoint2D contacto = collision.GetContact(0);
        GameObject fx = Instantiate(impactEffectPrefab, contacto.point, Quaternion.identity);
        Destroy(fx, effectDuration);
    }
}