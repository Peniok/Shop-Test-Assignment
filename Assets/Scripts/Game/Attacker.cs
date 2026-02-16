using UnityEngine;

public class Attacker : PlayerUnit
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float delayBetweenShoots;

    private Unit target;
    private float nextTimeToShot;

    private void Update()
    {
        if (Time.time > nextTimeToShot)
        {
            if (target == null)
            {
                target = battleManager.GetEnemyUnitToAttack();
            }
            Instantiate(bullet).Init(target, damage);
            nextTimeToShot += delayBetweenShoots;
        }
    }
}
