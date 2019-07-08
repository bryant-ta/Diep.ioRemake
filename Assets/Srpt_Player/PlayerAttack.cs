using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Player Attack Attributes
    public int priDmg;
    public float priPSpd;
    public float priCD;
    public float priAcc;
    public float priRec;
    //public float priPen; add penetration later?

    public GameObject initTank;
    public GameObject tank;

    List<Gun> guns;
    Camera viewCamera;

    bool doFireDelay;
    string[] tanksWithFireDelay = { "Twin", "Triplet", "Twin Flank", "Spread Shot", "Predator", "Streamliner", "Gunner", "Auto Gunner"};

    private void Start()
    {
        viewCamera = Camera.main;
        guns = new List<Gun>();

        Equip(initTank);
    }
    
    private void Update()
    {
        // Shoot Primary
        if (Input.GetButton("Fire1"))
        {
            if (!doFireDelay)
            {
                foreach (Gun gun in guns)
                {
                    gun.Fire(priDmg, priCD, priAcc, priRec, priPSpd, 1);
                }
            }
            else
                StartCoroutine(FireMyGuns());
        }

        // Rotate gun        
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector2 shootDir = mousePos - transform.position;

        float ang = Vector2.Angle(Vector2.right, shootDir);
        if (mousePos.y < transform.position.y) ang = ang + (2 * (180 - ang));
        tank.transform.rotation = Quaternion.Euler(0, 0, ang);
    }

    public void Equip(GameObject upgrade)
    {
        if (tank != null) Destroy(tank);
        guns.Clear();

        // This order to ensure instance attributes are set, not prefabs
        GameObject upgradeInst = Instantiate(upgrade, transform.position, transform.rotation, gameObject.transform);
        tank = upgradeInst;

        foreach (Transform gun in tank.transform)
        {
            if (gun.GetComponent<Spawner>() != null)
            {
                gun.GetComponent<Spawner>().Setup(gameObject, priDmg, priCD, priPSpd);
                continue;
            }
            else if (gun.GetComponent<Gun>() != null)
            {
                guns.Add(gun.GetComponent<Gun>());
                gun.GetComponent<Gun>().Setup(gameObject);
            }
        }

        doFireDelay = false;
        for (int i = 0; i < tanksWithFireDelay.Length; i++)
        {
            if (upgrade.name == tanksWithFireDelay[i])
            {
                doFireDelay = true;
            }
        }
    }

    IEnumerator FireMyGuns()
    {
        if (tank.name.Contains("Spread_Shot"))
        {
            guns[0].Fire(priDmg, priCD, priAcc, priRec, priPSpd, 1);
            yield return new WaitForSeconds(.1f);
            for (int i = 1; i < guns.Count; i += 2)
            {
                guns[i].Fire(priDmg, priCD, priAcc, priRec, priPSpd, 1);
                guns[i + 1].Fire(priDmg, priCD, priAcc, priRec, priPSpd, 1);
                yield return new WaitForSeconds(.1f);
            }
        }
        else
        {
            foreach (Gun gun in guns)
            {
                float fireDelay = gun.getAtt(gun.baseCooldown, priCD)*Random.Range(.5f,1.5f);
                gun.Fire(priDmg, priCD, priAcc, priRec, priPSpd, 1);
                yield return new WaitForSeconds(fireDelay);
                //yield return new WaitForSeconds(fireDelay);
            }
        }
    }
}
