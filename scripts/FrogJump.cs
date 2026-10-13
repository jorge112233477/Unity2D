using UnityEngine;

public class FrogJump : MonoBehaviour
{
    public float jumpForce = 8f;
    public float jumpInterval = 2f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(Jump), Random.Range(0.5f, 2f), jumpInterval);
    }

    void Jump()
    {
        Debug.Log(name + " salta");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}