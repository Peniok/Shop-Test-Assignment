using System;
using UnityEngine;

public class EnemyUnit : Unit
{
    private Unit target;

    private void Update()
    {
        if (target == null)
        {
            target = battleManager.GetPlayerUnitToAttack();
            target.Damage(damage);
        }
    }
}
