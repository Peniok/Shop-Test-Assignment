using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private List<Unit> playerUnits;
    private List<Unit> enemyUnits;

    private Action<Unit> onDieAction;

    private void Awake()
    {
        onDieAction += OnUnitDie;
        for (int i = 0; i < playerUnits.Count; i++)
        {
            playerUnits[0].Init(onDieAction);
        }
        for (int i = 0; i < playerUnits.Count; i++)
        {
            enemyUnits[0].Init(onDieAction);
        }
    }

    public Unit GetPlayerUnitToAttack()
    {
        Unit unit = TryToFindProvokerUnitToAttack();
        if (unit == null)
        {
            unit = playerUnits[0];
        }
        return unit;
    }

    private Unit TryToFindProvokerUnitToAttack()
    {
        return playerUnits.Find(unit => unit.GetType() == typeof(ArmoredProvoker));
    }

    public Unit GetEnemyUnitToAttack()
    {
        return enemyUnits[0];
    }

    private void OnUnitDie(Unit unit)
    {
        playerUnits.Remove(unit);
        enemyUnits.Remove(unit);
        if (playerUnits.Count == 0)
        {

        }
        else if (enemyUnits.Count == 0)
        {

        }
    }
}
