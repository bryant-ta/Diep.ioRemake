using UnityEngine;

// Base for any enemy that can use a Gun
public class BaseShooter : BaseEnemy
{
    public float attackDmgMult = 1;
    public float cooldownMult = 1;

    public Gun[] guns;

    public new void Setup()
    {
        base.Setup();
        foreach (Gun gun in guns)
        {
            gun.Setup(gameObject);
        }
    }

    public int FireGuns()
    {
        int numGunsFired = 0;
        for (int i = 0; i < guns.Length; i++)
        {
            if (guns[i].Fire(attackDmgMult) == 0)
                numGunsFired++;
        }
        return numGunsFired;
    }
}