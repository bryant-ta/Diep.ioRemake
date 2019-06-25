using UnityEngine;

// Base for any enemy that can use a Gun shooting Bullets
public class BulletShooter : BaseEnemy
{
    // BulletShooter Attributes
    public float fireCooldownFac = 1;       // How often Enemy decides to fire
    public float accuracyFac = 1;

    // Equipped Guns attribute
    public float gunAttackDmgMult = 1;  // Multiplier on Gun damage
    public float gunCooldownMult = 1;   // Multiplier on Gun firerate

    public Gun[] guns;

    private void Awake()
    {
        Setup();
    }

    public new void Setup()
    {
        base.Setup();
        foreach (Gun gun in guns)
        {
            gun.Setup(gameObject);
        }
    }

    float nextFire = Constants.ACTIVATE_ENEMY_DELAY;
    private void Update()
    {
        if (Time.time > nextFire)
        {
            FireGuns();
            nextFire = Time.time + fireCooldownFac + Random.Range(0f, Constants.ENEMY_FIRE_RANDOM_DELAY);
        }
    }

    public int FireGuns()
    {
        int numGunsFired = 0;
        for (int i = 0; i < guns.Length; i++)
        {
            if (guns[i].Fire(gunAttackDmgMult, gunCooldownMult, accuracyFac) == 0)
                numGunsFired++;
        }
        return numGunsFired;
    }
}