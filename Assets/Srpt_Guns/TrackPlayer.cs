using UnityEngine;

// Target objects tag "Player"
// Attach to top layer object of Gun
public class TrackPlayer : MonoBehaviour
{
    GameObject gunObject;
    GameObject target;

    void Awake()
    {
        gunObject = gameObject;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Rotate gun        
        Vector2 shootDir = target.transform.position - transform.position;

        float ang = Vector2.Angle(Vector2.right, shootDir);
        if (target.transform.position.y < transform.position.y) ang = ang + (2 * (180 - ang));
        gunObject.transform.rotation = Quaternion.Euler(0, 0, ang);
    }
}