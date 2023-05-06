using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            enemyHealth.takeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
