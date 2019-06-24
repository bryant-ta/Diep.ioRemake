using UnityEngine;

// Note - all attack damage factor from gun and player
public class Gun : MonoBehaviour
{
    // Gun Attributes
    [SerializeField] int baseAttackDmg = 1;
    [SerializeField] float baseCooldown = 1;          // Lower is faster

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

    public int Fire(float attackDmgFac = 1, float cooldownFac = 1)
    {
        return TryFire(getAttackDamage(attackDmgFac), getCooldown(cooldownFac));
    }

    public int TryFire(int attackDmg, float cooldown)
    {
        if (canFire)
        {
            GameObject projObjInst = Instantiate(projectile, projSpawn.position, transform.rotation);
            if (projObjInst == null) return -1;
            projObjInst.GetComponent<Projectile>().Setup(gameObject, attackDmg);

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
    public int getCooldown(float factor = 1) { return Mathf.FloorToInt(baseCooldown * factor); }
}
