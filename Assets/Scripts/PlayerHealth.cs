using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float RTHealth;
    public Text healthText;

    public void updateUI()
    {
        healthText.text = "Health: " + RTHealth;
    }
    public void takeDamage(float healthAmount)
    {
        RTHealth = RTHealth - healthAmount;
        if (RTHealth <= 0)
        {
            Respawn();
        }
        updateUI();
    }

    public void Heal(float healthAmount)
    {
        RTHealth = RTHealth + healthAmount;
        RTHealth = Mathf.Clamp(RTHealth, 0, maxHealth);
    }

    public void Respawn()
    {
        RTHealth = maxHealth;
        transform.position = new Vector3(0, 1, 0);
        updateUI();
    }
    public void Start()
    {
        RTHealth = maxHealth;
        updateUI();
    }
}
