using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLayerObject : MonoBehaviour
{
    
    public static bool Hit(LayerMask mask, Vector2 origin, Vector2 direction, out RaycastHit2D hit)
    {
        print(origin);
        print(direction);
        hit = Physics2D.Linecast(origin, direction);

        Debug.DrawLine(origin, direction, Color.red, 100f);
        if(hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
