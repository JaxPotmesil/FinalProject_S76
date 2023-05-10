using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ULT_Ability : MonoBehaviour
{
    public List<EnemyHealth> enemyhealth;
    public RectTransform TargetIndicator;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float duration;
    [SerializeField]
    private bool CanUse = true;
    [SerializeField]
    public bool active;

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            return;
        }
        Vector2 closestScreenPos = new Vector2(10000, 10000);
        foreach(EnemyHealth g in enemyhealth)
        {
            Vector3 v3ScreenPos = Camera.main.WorldToScreenPoint(g.transform.position);
            Vector2 screenPos = (Vector2) v3ScreenPos - new Vector2(Screen.width/2, Screen.height/2);
            if (screenPos.magnitude<closestScreenPos.magnitude && !g.DeathCheck && v3ScreenPos.z > 0)
            {
                closestScreenPos = screenPos;
            }
        }
        TargetIndicator.position = closestScreenPos + new Vector2(Screen.width / 2, Screen.height / 2);

    }

    public void getULTInput(InputAction.CallbackContext context)
    {
        if (context.performed && CanUse)
        {
            TargetIndicator.gameObject.SetActive(true);
            active = true;
            CanUse = false;
            StartCoroutine(coolDown());
            StartCoroutine(Active());
        }

    }

    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(cooldown);
        CanUse = true;
    }

    IEnumerator Active()
    {
        yield return new WaitForSeconds(duration);
        active = false;
        TargetIndicator.gameObject.SetActive(false);
    }
}
