using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTarget : TargetBase
{
   public override void NotifyShot()
   {
        Destroy(gameObject);
   }

    public override void NotifyExplosion(Explosion explosion)
    {
        Destroy(gameObject);
    }

}
