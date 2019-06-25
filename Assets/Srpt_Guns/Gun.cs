using UnityEngine;

// Gun that can shoot Bullets
// Note - all attack damage factor from gun and player
public class Gun : MonoBehaviour
{
    // Gun Attributes
    [SerializeField] int baseAttackDmg = 1;
    [SerializeField] float baseCooldown = 1;    // Lower is faster
    [Range(0, 100)] [SerializeField] float baseAccuracy = 100; // 100=perfect accuracy
    [SerializeField] float baseBulletSpeed = 1;
    [SerializeField] float baseBulletLifetime = 1;

    // Gun Info
    public string name;
    public GameObject owner;

    public GameObject projectile;
    public Transform projSpawn;

    bool canFire = false;

    public void Setup(GameObject owner, string name = "Gun")
    {
        gameObject.name = name;
        this.owner = owner;
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

    public int Fire(float attackDmgFac = 1, float cooldownFac = 1, float accuracyFac = 1)
    {
        return TryFire(getAttackDamage(attackDmgFac), getCooldown(cooldownFac), getAccuracy(accuracyFac));
    }

    public int TryFire(int attackDmg, float cooldown, float accuracy)
    {
        if (canFire)
        {
            GameObject projObjInst = Instantiate(projectile, projSpawn.position, transform.rotation);
            if (projObjInst == null) return -1;
            projObjInst.GetComponent<Bullet>().Setup(gameObject, attackDmg, accuracy);

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
    public int getAttackDamage(float factor = 1) { return Mathf.FloorToInt(baseAttackDmg * factor); }
    public float getCooldown(float factor = 1) { return baseCooldown * factor; }
    public float getAccuracy(float factor = 1)
    {
        float acc = baseAccuracy * factor;
        if (acc > 100) acc = 100;
        else if (acc < 0) acc = 0;
        return acc;
    }
    public int getUnboundedAttInt(float baseAtt, float factor = 1) { return Mathf.FloorToInt(baseAtt * factor); }
    public float getUnboundedAtt(float baseAtt, float factor = 1) { return Mathf.FloorToInt(baseAtt * factor); }
}
