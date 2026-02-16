using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Unit target;
    private float damage;

    public void Init(Unit target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 10);

        if(Vector3.Distance(transform.position, target.transform.position) < 1)
        {
            target.Damage(damage);
            gameObject.SetActive(false);
        }
    }
}
