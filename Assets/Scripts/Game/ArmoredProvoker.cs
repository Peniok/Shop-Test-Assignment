using UnityEngine;

public class ArmoredProvoker : PlayerUnit 
{
    public override void Damage(float damage)
    {
        damage *= 0.5f;
        base.Damage(damage);
    }
}
