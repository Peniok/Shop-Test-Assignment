using System;
using UnityEngine;

public class Attacker : PlayerUnit
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float delayBetweenShoots;

    private Unit target;
    private float nextTimeToShot;

    public override void Init(Action<Unit> onDieAction, int hp, float damage, BattleManager battleManager)
    {
        base.Init(onDieAction, hp, damage, battleManager);

        nextTimeToShot = Time.time + delayBetweenShoots;
    }

    private void Update()
    {
        if (Time.time > nextTimeToShot)
        {
            if (target == null)
            {
                target = battleManager.GetEnemyUnitToAttack();
            }
            Instantiate(bullet, transform.position,Quaternion.identity, transform.parent).Init(target, damage);
            nextTimeToShot += delayBetweenShoots;
        }
    }
}
