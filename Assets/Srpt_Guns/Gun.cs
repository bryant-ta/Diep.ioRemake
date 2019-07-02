using UnityEngine;

// Gun that can shoot Bullets
// Note - all attack damage factor from gun and player
public class Gun : MonoBehaviour
{
    // Gun Attributes
    public int baseAttackDmg = 1;
    public float baseCooldown = 1;    // Lower is faster
    [Range(0, 100)] public float baseAccuracy = 100; // 100=perfect accuracy
    public float baseRecoil = 1;

    // Bullet Attributes inherited from Gun & owner
    public float baseBulletSpeed = 1;
    public float baseBulletLifetime = 1;

    // Gun Info
    public string name;
    public GameObject owner;

    public GameObject projectile;
    public Transform projSpawn;

    GameObject barrel;

    bool canFire = false;

    public void Setup(GameObject owner, string name = "Gun")
    {
        gameObject.name = name;
        this.owner = owner;
        barrel = transform.GetChild(0).gameObject;
    }

    float nextFire = Constants.ACTIVATE_GUN_DELAY;
    private void Update()
    {
        // Check attack cooldown
        if (Time.time > nextFire)
        {
            canFire = true;
        }
    }

    public int Fire(float attackDmgFac = 1, float cooldownFac = 1, float accuracyFac = 1, float recoilFac = 1, float bulletSpeedFac = 1, float bulletLifetimeFac = 1)
    {
        return TryFire(getAttInt(baseAttackDmg, attackDmgFac), getAtt(baseCooldown, cooldownFac), getAtt(baseAccuracy, accuracyFac), getAtt(baseRecoil, recoilFac), getAtt(baseBulletSpeed, bulletSpeedFac), getAtt(baseBulletLifetime, bulletLifetimeFac));
    }

    public int TryFire(int attackDmg, float cooldown, float accuracy, float recoil, float movespeed, float lifetime)
    {
        if (canFire)
        {
            GameObject projObjInst = Instantiate(projectile, projSpawn.position, transform.rotation);
            if (projObjInst == null) return -1;
            projObjInst.GetComponent<Bullet>().Setup(gameObject, attackDmg, accuracy, movespeed, lifetime);
            
            owner.GetComponent<Rigidbody2D>().AddForce(-projObjInst.GetComponent<Bullet>().getMoveDir() * recoil * 10);

            nextFire = Time.time + cooldown;
            canFire = false;
            return 0;
        }
        else
        {
            return -1;
        }
    }

    // Use to access Gun attributes, allow inputting a multiplier
    public int getAttInt(float baseAtt, float factor = 1) { return Mathf.FloorToInt(baseAtt * factor); }
    public float getAtt(float baseAtt, float factor = 1) { return baseAtt * factor; }
    public float getAccuracy(float factor = 1)
    {
        float acc = baseAccuracy * factor;
        if (acc > 100) acc = 100;
        else if (acc < 0) acc = 0;
        return acc;
    }

    public GameObject getBarrel() { return barrel; }
}
