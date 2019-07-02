using UnityEngine;

public class MoveToTarget : BaseEnemyMovement
{
    private void Update()
    {
        Vector2 dir = (enemy.curTarget.transform.position - transform.position).normalized;
        rb.MovePosition((Vector2)transform.position + dir * moveSpeed * Time.deltaTime);
    }
}