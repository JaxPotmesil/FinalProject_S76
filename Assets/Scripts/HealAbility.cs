using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealAbility : MonoBehaviour
{
    public GameObject healPrefab;
    [SerializeField]
    private float coolDown;
    private bool offCool = true;

    public void GetHealAbility(InputAction.CallbackContext context)
    {
        if (offCool)
        {
            GameObject g = Instantiate(healPrefab);
            g.transform.position = transform.position - Vector3.up;
            StartCoroutine(ResetCoolDown());
        }
        
    }
    IEnumerator ResetCoolDown()
    {
        yield return new WaitForSeconds(coolDown);
        offCool = true;
    }
}
