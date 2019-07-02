using UnityEngine;

public class MoveFloat : BaseEnemyMovement
{
    SpriteRenderer sr;

    private void Start()
    {
        base.Setup();
        sr = GetComponent<SpriteRenderer>();

        Vector2 dir = Random.insideUnitCircle;
        rb.AddForce(dir * moveSpeed * 100 * Random.Range(0.5f, 1.0f));
        
        rb.AddTorque(Random.Range(-2.0f, 2.0f));
    }

    private void Update()
    {
        if (rb.velocity.magnitude < moveSpeed) rb.velocity = rb.velocity.normalized;
    }
}