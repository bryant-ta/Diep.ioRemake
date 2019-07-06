using UnityEngine;
using System.Collections.Generic;

// Target objects tag "Player"
// Attach to top layer object of Gun
public class TrackTarget : MonoBehaviour
{
    public GameObject obj;  // Thing to rotate
    public GameObject defaultTarget;

    GameObject target;      // Thing currently tracking
    List<GameObject> seen;

    float closestDis = 100000;
    int flip;

    void Awake()
    {
        seen = new List<GameObject>();
        if (seen.Count != 0) target = seen[0];
    }

    float nextCleanUp;
    private void Update()
    {
        // Clean up null references in seen List
        if (Time.time > nextCleanUp)
        {
            nextCleanUp = Time.time + 1;
            for (int i = seen.Count - 1; i > -1; i--)
            {
                if (seen[i] == null)
                    seen.RemoveAt(i);
            }
        }

        // Retarget to next obj if current target was destroyed/removed
        if (target == null)
        {
            for (int i = 0; i < seen.Count; i++)
            {
                if (seen[i] != null)
                {
                    target = seen[i];
                    break;
                }
            }

            if (target == null)
            {
                if (defaultTarget != null) target = defaultTarget;
                else return;
            }
        }

        // Rotate gun        
        Vector2 shootDir = target.transform.position - transform.position;

        float ang = Vector2.Angle(Vector2.right, shootDir);
        if (target.transform.position.y < transform.position.y) ang = ang + (2 * (180 - ang));
        obj.transform.rotation = Quaternion.Euler(0, 0, ang + flip);
    }

    public void Flip(bool flipping)
    {
        if (flipping)
            flip = 180;
        else
            flip = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Damageable>() != null)
        {
            seen.Add(col.gameObject);
            float dis = (transform.position - col.transform.position).magnitude;
            if (dis < closestDis)
            {
                closestDis = dis;
                target = col.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        seen.Remove(col.gameObject);
        if (col.gameObject == target)
        {
            print("exit");
            closestDis = 10000;
            foreach (GameObject obj in seen)
            {
                float dis = (transform.position - col.transform.position).magnitude;
                if (dis < closestDis)
                {
                    target = obj;
                }
            }

            if (target == col.gameObject)
            {
                target = null;
                obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    public void ResetTarget()
    {
        for (int i = 0; i < seen.Count; i++)
        {
            if (seen[i] != null)
            {
                target = seen[i];
                break;
            }
        }

        target = defaultTarget;
    }
}