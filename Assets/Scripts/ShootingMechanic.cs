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
    public ULT_Ability ULT;
    

    IEnumerator shootDelay()
    {
        
        yield return new WaitForSeconds(1 / fireRate);
        
        GameObject g = Instantiate(bullet);
        Vector3 target = new Vector3();
        Vector3 screenPos = new Vector3();
        if (ULT.active)
        {
            screenPos = ULT.TargetIndicator.position;
        }
        else
        {
            screenPos = new Vector3(Screen.width / 2, Screen.height / 2);
        }
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            target = hit.point;
        }
        else
        {
            target = ray.GetPoint(100);
        }
       
        g.transform.position = gun.transform.position;
        g.transform.LookAt(target, Vector3.up);
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
