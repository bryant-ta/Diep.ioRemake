using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public static Vector2[] DIAGONAL_VECTORS = new[]
        {new Vector2(1,1).normalized,      // 0 - TR
         new Vector2(-1,1).normalized,     // 1 - TL
         new Vector2(-1,-1).normalized,    // 2 - BL
         new Vector2(1,-1).normalized};    // 3 - BR
}
