using UnityEngine;

public class Gunner : BaseShooter
{
    void Awake()
    {
        base.Setup();
    }

    private void Update()
    {
        FireGuns();
    }
}