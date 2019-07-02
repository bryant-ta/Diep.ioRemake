using UnityEngine;

public class ExpandFOV : MonoBehaviour
{
    public int expandAmt;

    void Awake()
    {
        Camera.main.orthographicSize += expandAmt;
    }
}