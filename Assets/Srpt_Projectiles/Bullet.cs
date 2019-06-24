using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
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
            if (fromPlayer && col.tag == "Enemy")
            {
                col.GetComponent<Damageable>().DoDamage(parentGun.attackDmg);
            }
            else if (!fromPlayer && col.tag == "Player")
            {
                col.GetComponent<Damageable>().DoDamage(parentGun.attackDmg);
            }
            else
            {
                col.GetComponent<Damageable>().DoDamage(parentGun.attackDmg);
            }
        }
    }
}
