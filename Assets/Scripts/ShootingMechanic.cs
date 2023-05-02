using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShootingMechanic : MonoBehaviour
{
    public GameObject bullet;
    private bool canShoot = true;
    [SerializeField]
    private float fireRate;
    public GameObject gun;
    public GameObject HelexBullet;
    private bool canShootHelex = true;
    [SerializeField]
    private float helexCoolDown;
    

    IEnumerator shootDelay()
    {
        
        yield return new WaitForSeconds(1 / fireRate);
        
        GameObject g = Instantiate(bullet);
        g.transform.position = gun.transform.position;
        g.transform.rotation = gun.transform.rotation;
        StartCoroutine(shootDelay());
        
    }
    public void getShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(shootDelay());
        }
        else if (context.canceled)
        {
            StopAllCoroutines();
        }
    }

    public void getHelex(InputAction.CallbackContext context)
    {
        if (context.performed && canShootHelex)
        {
            GameObject g = Instantiate(HelexBullet);
            g.transform.position = gun.transform.position;
            g.transform.rotation = gun.transform.rotation;
            canShootHelex = false;
            StartCoroutine(WaitForHelex());
        }
        
    }
    IEnumerator WaitForHelex()
    {
        yield return new WaitForSeconds(helexCoolDown);
        canShootHelex = true;
    }
    

}
