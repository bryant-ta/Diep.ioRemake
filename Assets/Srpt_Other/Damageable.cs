using UnityEngine;

[System.Serializable]
public class Damageable : MonoBehaviour
{
    [SerializeField] int hp;        // Health
    [SerializeField] int maxhp;
    int shd;                        // Shield
    int maxshd;
    private float shdDelay;         // Seconds until shield starts regen
    private float shdRegen;         // Shield amt to regen each second

    float shdTimer;

    public void Setup(int maxhp, int maxshd = 0)
    {
        hp = maxhp;
        this.maxhp = maxhp;
        shd = maxshd;
        this.maxshd = maxshd;
    }

    void Update()
    {
        doShdTick();
    }

    public void DoDamage(int amt)
    {
        // Do damage, then check if death
        hp -= amt;
        if (hp <= 0)
        {
            Die();
        }

        // Do shield operations
        shdTimer = Time.time + shdDelay;
    }
    
    // Health Functions

    public void AddHP(int amt)
    {
        hp += amt;
        if (hp > maxhp) hp = maxhp;
    }

    public void AddMaxHP(int amt)
    {
        maxhp += amt;
        hp += amt;
    }

    // Shield Functions

    public void AddShd(int amt)
    {
        shd += amt;
        if (shd > maxshd) shd = maxshd;
    }

    public void AddMaxShd(int amt)
    {
        maxshd += amt;
        shd += amt;
    }

    void doShdTick()
    {
        if (Time.time > shdTimer && shd < maxshd)
        {
            AddShd(Mathf.FloorToInt(Time.deltaTime * shdRegen));
        }
    }

    // Death Functions

    public void Die()
    {
        Destroy(gameObject);
    }

    public int getHP() { return hp; }
    public int getMaxHP() { return maxhp; }
}
