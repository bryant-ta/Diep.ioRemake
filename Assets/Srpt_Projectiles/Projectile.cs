using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Gun parentGun;
    public bool fromPlayer;
    public int dmg;

    public void Setup(GameObject caller, int dmg)
    {
        parentGun = caller.GetComponent<Gun>();
        if (parentGun.owner.tag == "Player") fromPlayer = true;
        this.dmg = dmg;
    }
}
