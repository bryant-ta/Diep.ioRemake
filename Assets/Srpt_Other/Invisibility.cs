using UnityEngine;

public class Invisibility : MonoBehaviour
{
    public float invisTime; // Time to go fully invis

    Damageable dm;
    SpriteRenderer sp_body;
    SpriteRenderer sp_barrel;

    int curHP;

    void Awake()
    {
        dm = GetComponent<Damageable>();
        sp_body = GetComponent<SpriteRenderer>();
        sp_barrel = transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>();
        curHP = dm.getHP();
    }

    float t;
    private void Update()
    {
        t += Time.deltaTime;
        float t_percent = t / invisTime;
        Color c = sp_body.color;
        c.a = Mathf.Lerp(1, 0, t);
        sp_body.color = c;
        sp_barrel.color = c;
    }
}