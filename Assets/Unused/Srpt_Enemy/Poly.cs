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
    }
}
