using UnityEngine;

public class Drone : Bullet
{
    public float maxSpeed;

    Rigidbody2D rb;
    Collider2D m_collider;
    
    TrackTarget tt;
    GameObject mouseObj;

    int flip = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tt = GetComponent<TrackTarget>();
        tt.defaultTarget = parentGun.gameObject;
        m_collider = GetComponent<CircleCollider2D>();
        mouseObj = GameObject.Find("MousePos");
    }

    void Update()
    {
        flip = 1;
        if (Input.GetButton("Fire1"))
        {
            mouseObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            tt.SetTarget(mouseObj);
        }
        else if (Input.GetButton("Fire2"))
        {
            flip = -1;
            mouseObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            tt.SetTarget(mouseObj);
        }
        else if (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Fire2"))
        {
            tt.ResetTarget();
        }
        rb.AddForce(transform.right * moveSpeed * flip);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (parentGun.owner == col.gameObject)
        {
            Physics2D.IgnoreCollision(col.collider, m_collider);
        }
    }

    private void OnDestroy()
    {
        if (parentGun != null)
            parentGun.gameObject.GetComponent<Spawner>().DroneDied();
    }
}