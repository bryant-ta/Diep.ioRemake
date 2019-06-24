using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float moveSpeed;
    public float lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(transform.right * moveSpeed * Time.deltaTime, Space.World);
    }
}
