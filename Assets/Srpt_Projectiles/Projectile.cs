using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Gun parentGun;
    public bool fromPlayer;

    public void Setup(GameObject caller)
    {
        parentGun = caller.GetComponent<Gun>();
        if (parentGun.owner.tag == "Player") fromPlayer = true;
    }
}
