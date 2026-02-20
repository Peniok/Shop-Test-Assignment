using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private Attacker attackerPrefab;
    [SerializeField] private ArmoredProvoker armoredProvokerPrefab;
    [SerializeField] private List<Unit> enemyUnits;
    [SerializeField] private List<Transform> playerUnitsPlaces;

    private List<Unit> playerUnits = new List<Unit>();

    private Action<Unit> onDieAction;
    private Action onBattleEndedAction;

    public void Init(Action onBattleEndedAction, List<string> purchasedCharactersId, List<int> pickedCharactersToBattle)
    {
        this.onBattleEndedAction = onBattleEndedAction;

        onDieAction += OnUnitDie;
        for (int i = 0; i < pickedCharactersToBattle.Count; i++)
        {
            string idOfPickedUnit = purchasedCharactersId[pickedCharactersToBattle[i]];
            UnitConfig unitConfig = GameServices.ItemsConfig.GetUnitConfig(idOfPickedUnit);
            if (unitConfig.UnitType == PlayerUnitType.Attacker)
            {
                playerUnits.Add(Instantiate(attackerPrefab, playerUnitsPlaces[i]));
            }
            else if (unitConfig.UnitType == PlayerUnitType.ArmoredProvoker)
            {
                playerUnits.Add(Instantiate(armoredProvokerPrefab, playerUnitsPlaces[i]));
            }

            playerUnits[i].Init(onDieAction, unitConfig.HP, unitConfig.Damage, this);
        }


        for (int i = 0; i < enemyUnits.Count; i++)
        {
            enemyUnits[i].Init(onDieAction, GameServices.EnemiesConfig.HP, GameServices.EnemiesConfig.Damage, this);
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

        CheckForLevelEnd();
    }

    private void CheckForLevelEnd()
    {
        if (playerUnits.Count == 0 || enemyUnits.Count == 0)
        {
            DisableAllSurvivedUnits(playerUnits.Count == 0 ? enemyUnits : playerUnits);

            StartCoroutine(WaitAndShowEndOfBattle());
        }

        void DisableAllSurvivedUnits(List<Unit> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                units[i].enabled = false;
            }
        }
    }

    IEnumerator WaitAndShowEndOfBattle()
    {
        yield return new WaitForSeconds(1);
        onBattleEndedAction.Invoke();
        Destroy(gameObject);
    }
}
