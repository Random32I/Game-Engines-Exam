using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public interface Commands
{
    public static Collider2D Shoot(bool inverted, out Vector3 pos)
    {
        int inverse = 1;
        if (inverted)
        {
            inverse = -1;
        }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition) * inverse - Camera.main.transform.forward * -10, Camera.main.transform.forward);
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) * inverse - Camera.main.transform.forward * -10;
        if (hit)
        {
            return hit.collider;
        }
        return null;
    }
}
