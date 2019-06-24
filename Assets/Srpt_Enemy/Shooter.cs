using UnityEngine;

public class Shooter : BaseEnemy
{
    public Gun gun;

    void Awake()
    {
        base.Setup();
    }
}