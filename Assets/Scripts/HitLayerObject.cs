using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLayerObject : MonoBehaviour
{
    
    public static bool Hit<T>(LayerMask mask, Vector2 origin, Vector2 direction, out RaycastHit2D hit)
    {
        hit = Physics2D.Linecast(origin, direction, mask);

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
