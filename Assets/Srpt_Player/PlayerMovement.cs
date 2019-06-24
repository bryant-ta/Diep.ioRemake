using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D rb;

    Vector2 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get movement input
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        // Move tank
        rb.AddForce(velocity, ForceMode2D.Impulse);
        //rb.transform.Translate(velocity * Time.deltaTime);
    }
}
