using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ULT_Ability : MonoBehaviour
{
    public List<GameObject> enemy;
    public RectTransform TargetIndicator;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float duration;
    [SerializeField]
    private bool CanUse = true;
    [SerializeField]
    private bool active;

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            return;
        }
        Vector2 closestScreenPos = new Vector2(10000, 10000);
        foreach(GameObject g in enemy)
        {
            Vector2 screenPos = (Vector2)Camera.main.WorldToScreenPoint(g.transform.position)- new Vector2(Screen.width/2, Screen.height/2);
            if (screenPos.magnitude<closestScreenPos.magnitude)
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
