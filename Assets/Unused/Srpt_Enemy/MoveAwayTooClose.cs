using UnityEngine;

public class MoveAwayTooClose : BaseEnemyMovement
{
    public float closeDis;

    private void Update()
    {
        Vector2 dir = enemy.curTarget.transform.position - transform.position;

        if (dir.magnitude < closeDis)
        {
            rb.MovePosition((Vector2)transform.position - dir.normalized * moveSpeed * Time.deltaTime);
        }
    }
}