using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note - all attack damage factor from gun and player
public class Gun : MonoBehaviour
{
    // Gun Attributes
    public float cooldownMult = 1;          // Lower is faster
    public int attackDmg = 1;

    // Gun Info
    public string name;
    public GameObject owner;

    public GameObject projectile;
    public Transform projSpawn;

    public void Setup(GameObject owner, string name = "Gun")
    {
        gameObject.name = name;
        this.owner = owner;
    }

    public void Fire()
    {
        GameObject projObjInst = Instantiate(projectile, projSpawn.position, transform.rotation);
        projObjInst.GetComponent<Projectile>().Setup(gameObject);
    }
}
