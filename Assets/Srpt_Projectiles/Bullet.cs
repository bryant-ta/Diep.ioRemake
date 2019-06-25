using UnityEngine;

public class Bullet : Projectile
{
    // Bullet Attributes
    [ShowOnly] public float moveSpeed;
    [ShowOnly] public float lifetime;

    Vector2 dir;

    public void Setup(GameObject caller, int dmg, float accuracy, float moveSpeed, float lifetime)
    {
        base.Setup(caller, dmg, accuracy);
        this.lifetime = lifetime;
        dir = (Quaternion.Euler(0, 0, shotAngle) * Vector2.right);

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Damageable>() != null)
        {
            if (fromPlayer && col.tag == "Enemy")           // Hit Enemy
            {
                col.GetComponent<Damageable>().DoDamage(dmg);
                Destroy(gameObject);
            }
            else if (!fromPlayer && col.tag == "Player")    // Hit Player
            {
                col.GetComponent<PlayerHealth>().DoDamage(dmg);
                Destroy(gameObject);
            }
            else if (col.tag == "Environment")
            {
                col.GetComponent<Damageable>().DoDamage(dmg);
                Destroy(gameObject);
            }
        }

        if (col.tag == "Environment")
        {
            Destroy(gameObject);
        }
    }
}
