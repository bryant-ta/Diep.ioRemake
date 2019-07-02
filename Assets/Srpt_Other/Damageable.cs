using UnityEngine;

[System.Serializable]
public class Damageable : MonoBehaviour
{
    [SerializeField] int hp;        // Health
    [SerializeField] int maxhp;

    public void Setup(int maxhp, int maxshd = 0)
    {
        hp = maxhp;
        this.maxhp = maxhp;
    }

    public void DoDamage(int amt)
    {
        // Do damage, then check if death
        hp -= amt;
        if (hp <= 0)
        {
            Die();
        }
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

    // Death Functions

    public void Die()
    {
        Destroy(gameObject);
    }

    public int getHP() { return hp; }
    public int getMaxHP() { return maxhp; }
}
