using UnityEngine;

public class Poly : Damageable
{
    public Sprite[] body;

    SpriteRenderer sr;

    private void Awake()
    {
        base.Setup(getMaxHP());
        sr = GetComponent<SpriteRenderer>();

        sr.sprite = body[Random.Range(0, body.Length)];
    }
}
