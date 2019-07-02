using UnityEngine;

public class MoveErratic : BaseEnemyMovement
{
    public float nextDirInterval;
    public float forceDur;

    Vector2 dir;

    float nextDir = -1;
    float forceDurMark;
    private void Update()
    {
        if (Time.time > nextDir)
        {
            dir = Random.insideUnitCircle;
            nextDir = Time.time + nextDirInterval;
            forceDurMark = Time.time + forceDur;
        }

        if (forceDurMark > Time.time)
        {
            rb.AddForce(dir * moveSpeed * 0.1f);
        }
    }
}