using UnityEngine;

// Base for any enemy. tag with Enemy
public class BaseEnemy : Damageable
{
    public float moveSpeed;
    public int attackDmg;
    public float exp;           // Raw exp value given to player on kill

    [HideInInspector] public Rigidbody2D rb;

    public void Setup()
    {
        base.Setup(getMaxHP());
        rb = GetComponent<Rigidbody2D>();
    }
}
