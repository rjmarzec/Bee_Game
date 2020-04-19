using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeFlower : Unit
{
    // When called, launch a projectile from the unit, as specified by
    // the public variables of unit.
    override public void Attack()
    {
        // The flower bee generates resource rather than shooting projectiles

        if(direction >= 0)
        {
            GlobalVariables.IncLeftHoneyCount();
        }
        else
        {
            GlobalVariables.IncRightHoneyCount();
        }
    }
}
