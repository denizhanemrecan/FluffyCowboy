using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    float damage = 10f;
    Vector3 projectileDirection;
    Rigidbody rBody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBase>())
        {
            other.GetComponent<EnemyBehaviour>().takeHit((int)damage);
        }

        if (!other.GetComponent<EnemyProjectile>() || !other.GetComponent<Player>())
        {
            Destroy(gameObject);
        }  
    }

    public void Fire(float speed, float _damage, Vector3 direction, Vector3 position)
    {
        damage = _damage;
        rBody = GetComponent<Rigidbody>();
        rBody.velocity = Vector3.zero;
        transform.position = position;
        transform.forward = direction;
        projectileDirection = direction;

        rBody.AddForce(direction.normalized * speed, ForceMode.VelocityChange);
        transform.rotation = Quaternion.LookRotation(direction, transform.forward);
    }

    
}
