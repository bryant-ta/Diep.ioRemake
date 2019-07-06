using UnityEngine;

public class Invisibility : MonoBehaviour
{
    public float invisTime;     // Time to go fully invis

    Vector3 lastPos;
    SpriteRenderer sp_body;
    SpriteRenderer sp_barrel;
    SpriteRenderer sp_extra;

    bool isLandmine;

    void Awake()
    {
        sp_body = GetComponent<SpriteRenderer>();
        if (gameObject.name.Contains("Landmine")) isLandmine = true;
        if (isLandmine)
        {
            sp_barrel = transform.GetChild(0).GetComponent<SpriteRenderer>();
            sp_extra = transform.GetChild(1).GetComponent<SpriteRenderer>();
        }
        else 
        {
            sp_barrel = transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>();
        }
    }

    float t;
    private void Update()
    {
        // Do invisibility
        t += Time.deltaTime;
        float t_percent = t / invisTime;
        Color c1 = sp_body.color;
        Color c2 = sp_barrel.color;
        c1.a = Mathf.Lerp(1, 0, t_percent);
        c2.a = Mathf.Lerp(1, 0, t_percent);
        sp_body.color = c1;
        sp_barrel.color = c2;

        if (isLandmine)
        {
            sp_extra.color = c2;
        }

        // Reset invis timer
        if (transform.position != lastPos)
        {
            t = 0;
            t_percent = 0;
            lastPos = transform.position;
        }
    }
}