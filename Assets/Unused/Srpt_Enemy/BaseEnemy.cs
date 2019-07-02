using UnityEngine;

// Base for any enemy. tag with Enemy
public class BaseEnemy : Damageable
{
    public float exp;           // Raw exp value given to player on kill

    [HideInInspector] public GameObject curTarget;

    public void Setup()
    {
        base.Setup(getMaxHP());
        curTarget = GameObject.FindGameObjectWithTag("Player");
    }
}
