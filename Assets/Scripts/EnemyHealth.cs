using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float RTHealth;
    [SerializeField]
    private float respawnTime;

    public void takeDamage(float healthAmount)
    {
        RTHealth = RTHealth - healthAmount;
        if (RTHealth <= 0)
        {
            StartCoroutine(Respawn());

        }
       
    }

    IEnumerator Respawn()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(respawnTime);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        RTHealth = maxHealth;
    }

}
