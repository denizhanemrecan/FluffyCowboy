using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int hitpoints;

    public int maxhitpoints = 5;

    public HealthBar healthbar;

    void Start()
    {
        hitpoints = maxhitpoints;
        healthbar.SetHealth(hitpoints, maxhitpoints);
    }

    public void takeHit(int damage)
    {
        hitpoints -= damage;

        if(hitpoints <=0)
        {
            Destroy(gameObject);
            StopAllCoroutines();
            ManagerProvider.Instance.DeleteEnemy(gameObject.GetComponent<EnemyBase>());
        }
    }

}
