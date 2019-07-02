using UnityEngine;

public class Rotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(transform.forward, 15 * Time.deltaTime);
    }
}