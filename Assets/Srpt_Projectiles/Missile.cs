using UnityEngine;

public class Missile : Bullet
{
    public Gun[] guns;

    private void Awake()
    {
        foreach (Gun gun in guns)
        {
            gun.Setup(gameObject);
        }
    }

    float nextFire;
    private void Update()
    {
        if (Time.time > nextFire)
        {
            foreach (Gun gun in guns)
            {
                gun.Fire();
            }
            nextFire = Time.time + .1f;
        }
    }
}