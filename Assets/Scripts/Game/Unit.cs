using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    private float hp;
    protected float damage;

    protected BattleController battleManager;
    private Action<Unit> onDieAction;

    public virtual void Init(Action<Unit> onDieAction, int hp, float damage, BattleController battleManager)
    {
        this.hp = hp;
        this.damage = hp;

        this.battleManager = battleManager;
        this.onDieAction = onDieAction;
    }

    public virtual void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        onDieAction.Invoke(this);
        Destroy(gameObject);
    }
}
