using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position - Vector3.forward*10, 0.1f);
    }
}