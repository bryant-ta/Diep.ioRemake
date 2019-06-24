using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Player Attack Attributes
    public float priCooldown;       // Primary Cooldown
    public float secCooldown;       // Primary Cooldown

    public GameObject primaryGunObject;
    public GameObject secondaryGunObject;

    Gun primary;
    Gun secondary;
    Camera viewCamera;

    float nextPriFire;
    float nextSecFire;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Equip(primaryGunObject);

        viewCamera = Camera.main;
    }

    private void Update()
    {
        // Shoot Primary
        if (Input.GetButton("Fire1") && Time.time > nextPriFire)
        {
            nextPriFire = Time.time + priCooldown * primary.cooldownMult;
            primary.Fire();
        }

        // Rotate gun        
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector2 shootDir = mousePos - transform.position;

        float ang = Vector2.Angle(Vector2.right, shootDir);
        if (mousePos.y < transform.position.y) ang = ang + (2 * (180 - ang));
        primaryGunObject.transform.rotation = Quaternion.Euler(0, 0, ang);
    }

    void Equip(GameObject gun)
    {
        // This order to ensure instance attributes are set, not prefabs
        GameObject gunInst = Instantiate(gun, transform.position, transform.rotation, gameObject.transform);
        gunInst.GetComponent<Gun>().Setup(gameObject);
        primaryGunObject = gunInst;
        primary = primaryGunObject.GetComponent<Gun>();
    }
}
