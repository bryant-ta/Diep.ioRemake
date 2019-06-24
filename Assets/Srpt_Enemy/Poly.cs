using UnityEngine;

public class Poly : BaseEnemy
{
    public Sprite[] body;

    SpriteRenderer sr;

    private void Awake()
    {
        base.Setup();
        sr = GetComponent<SpriteRenderer>();

        sr.sprite = body[Random.Range(0, body.Length)];

        Vector2 dir = Random.insideUnitCircle;
        rb.AddForce(dir * moveSpeed * 100 * Random.Range(0.5f, 1.0f));

        if (sr.sprite.name != "white_circle_100x100")
            rb.AddTorque(Random.Range(-2.0f, 2.0f));
    }
}
