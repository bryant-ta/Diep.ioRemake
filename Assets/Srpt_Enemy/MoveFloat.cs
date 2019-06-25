using UnityEngine;

public class MoveFloat : BaseEnemyMovement
{
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        Vector2 dir = Random.insideUnitCircle;
        rb.AddForce(dir * moveSpeed * 100 * Random.Range(0.5f, 1.0f));

        if (sr.sprite.name != "white_circle_100x100")
            rb.AddTorque(Random.Range(-2.0f, 2.0f));
    }
}