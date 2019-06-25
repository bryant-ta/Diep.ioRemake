using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Gun parentGun;
    [ShowOnly] public bool fromPlayer;
    [ShowOnly] public float shotAngle;

    [ShowOnly] public int dmg;

    public void Setup(GameObject caller, int dmg, float accuracy)
    {
        parentGun = caller.GetComponent<Gun>();
        if (parentGun.owner.tag == "Player") fromPlayer = true;
        this.dmg = dmg;

        shotAngle = ShotAngle(accuracy);
    }

    // Return Angle [-50, 50] affecting bullet trajectory
    // Expects accuracy in Range[0,100]
    // accuracy = 100 -> perfect accuracy
    float ShotAngle(float accuracy)
    {
        float angle = 50 - accuracy / 2f;
        float t = Random.Range(-angle, angle);
        return t;
    }
}
