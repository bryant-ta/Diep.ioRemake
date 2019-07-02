using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // [Description]_[Property]_[Type]
    // ex) [ENEMY_FIRE]_[RANDOM]_[DELAY]
    // All delays in seconds
    public static float ACTIVATE_GUN_DELAY = 1;
    public static float ACTIVATE_ENEMY_DELAY = 0;
    public static float ENEMY_FIRE_RANDOM_DELAY = 1.5f;

    public static Vector2[] DIAGONAL_VECTORS = new[]
        {new Vector2(1,1).normalized,      // 0 - TR
         new Vector2(-1,1).normalized,     // 1 - TL
         new Vector2(-1,-1).normalized,    // 2 - BL
         new Vector2(1,-1).normalized};    // 3 - BR

    // Use this for angle -> vector
    // dir = (Quaternion.Euler(0, 0, shotAngle) * Vector2.right);

    //public static Vector2 AngToDir(GameObject obj, float angleInDegrees, bool angleIsGlobal)
    //{
    //    if (!angleIsGlobal)
    //    {
    //        angleInDegrees += obj.transform.eulerAngles.z;
    //    }
    //    return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    //}
}
