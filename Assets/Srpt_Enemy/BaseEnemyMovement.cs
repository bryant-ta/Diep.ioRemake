using UnityEngine;

public class BaseEnemyMovement : MonoBehaviour
{
    public float moveSpeed;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public BaseEnemy enemy;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<BaseEnemy>();
    }
}