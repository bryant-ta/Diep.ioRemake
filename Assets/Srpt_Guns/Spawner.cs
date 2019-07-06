using UnityEngine;

public class Spawner : Gun
{
    public int maxDroneCount = 8;

    float attackDmgFac;
    float cooldownFac;
    float bulletSpeedFac;

    float spawnRate;
    int droneCount;

    public void Setup(GameObject obj, float attackDmgFac = 1, float cooldownFac = 1, float bulletSpeedFac = 1)
    {
        base.Setup(obj);
        this.attackDmgFac = attackDmgFac;
        this.cooldownFac = cooldownFac;
        this.bulletSpeedFac = bulletSpeedFac;
        spawnRate = getAtt(baseCooldown, cooldownFac);
    }

    float nextSpawn;
    private void Update()
    {
        if (droneCount < maxDroneCount && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            droneCount++;
            GameObject projObjInst = Instantiate(projectile, projSpawn.position, transform.rotation);
            projObjInst.GetComponent<Bullet>().Setup(gameObject, getAttInt(baseAttackDmg, attackDmgFac), 100, getAtt(baseBulletSpeed, bulletSpeedFac), baseBulletLifetime);
        }
    }

    public void DroneDied() { droneCount--; }
}