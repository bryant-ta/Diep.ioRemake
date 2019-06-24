using UnityEngine;

public class Bullet : Projectile
{
    // Bullet Attributes
    public float moveSpeed;
    public float lifetime;

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(transform.right * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Damageable>() != null)
        {
            if (fromPlayer && col.tag == "Enemy")           // Hit Enemy
            {
                col.GetComponent<Damageable>().DoDamage(dmg);
            }
            else if (!fromPlayer && col.tag == "Player")    // Hit Player
            {
                col.GetComponent<PlayerHealth>().DoDamage(dmg);
            }
            else
            {
                col.GetComponent<Damageable>().DoDamage(dmg);
            }
        }
    }
}
