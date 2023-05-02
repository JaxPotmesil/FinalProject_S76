using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    [SerializeField]
    private float shootSpeed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1 / shootSpeed);
        GameObject g = Instantiate(enemyBullet);
        g.transform.position = transform.position;
        StartCoroutine(Shoot());
    }
}
