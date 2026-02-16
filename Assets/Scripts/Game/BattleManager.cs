using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private ItemsConfig itemsConfig;
    [SerializeField] private EnemiesConfig enemiesConfig;
    [SerializeField] private SavesManager savesManager;
    [SerializeField] private Attacker attackerprefab;
    [SerializeField] private ArmoredProvoker armoredProvokerPrefab;
    [SerializeField] private List<Unit> enemyUnits;

    private List<Unit> playerUnits;

    private Action<Unit> onDieAction;

    private void Awake()
    {
        onDieAction += OnUnitDie;
        for (int i = 0; i < savesManager.PickedCharactersToBattle.Count; i++)
        {
            string idOfPickedUnit = savesManager.PurchasedCharactersId[savesManager.PickedCharactersToBattle[i]];
            UnitConfig unitConfig = itemsConfig.GetUnitConfig(idOfPickedUnit);
            if(unitConfig.UnitType == PlayerUnitType.Attacker)
            {
                playerUnits.Add(Instantiate(attackerprefab));
            }
            else if (unitConfig.UnitType == PlayerUnitType.ArmoredProvoker)
            {
                playerUnits.Add(Instantiate(armoredProvokerPrefab));
            }

            playerUnits[i].Init(onDieAction, unitConfig.HP, unitConfig.Damage, this);
        }


        for (int i = 0; i < enemyUnits.Count; i++)
        {
            enemyUnits[i].Init(onDieAction, enemiesConfig.HP, enemiesConfig.Damage, this);
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
