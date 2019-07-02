using UnityEngine;

// Base for any enemy that can use a Gun shooting Bullets
public class BulletShooter : BaseEnemy
{
    // BulletShooter Attributes
    public float fireCooldownFac = 1;       // How often Enemy decides to fire

    // Equipped Guns attribute
    public float gunAttackDmgFac = 1;   // Multiplier on Gun damage
    public float gunCooldownFac = 1;    // Multiplier on Gun firerate
    public float gunAccuracyFac = 1;    // Multiplier on Gun accuracy
    public float bulletSpeedFac = 1;    // Multiplier on Bullet Speed
    public float bulletLifeTimeFac = 1; // Multiplier on Bullet Lifetime

    public Gun[] guns;

    float nextFire;

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
        nextFire = Constants.ACTIVATE_ENEMY_DELAY + Random.Range(0f, Constants.ENEMY_FIRE_RANDOM_DELAY);
    }

    private void Update()
    {
        if (Time.time > nextFire)
        {
            FireGuns();
            nextFire = Time.time + 0.1f;
            //nextFire = Time.time + Random.Range(0f, Constants.ENEMY_FIRE_RANDOM_DELAY);
        }
    }

    public int FireGuns()
    {
        int numGunsFired = 0;
        foreach (Gun gun in guns)
        {
            if (gun.Fire(gunAttackDmgFac, gunCooldownFac, gunAccuracyFac, bulletSpeedFac, bulletLifeTimeFac) == 0)
                numGunsFired++;
        }
        return numGunsFired;
    }
}