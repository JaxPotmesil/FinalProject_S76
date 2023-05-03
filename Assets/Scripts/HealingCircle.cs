using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCircle : MonoBehaviour
{
    [SerializeField]
    private float duration;
    [SerializeField]
    private float healthPerSec;
    private PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            player.Heal(healthPerSec * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            player = playerHealth;
        }
        Debug.Log("print here");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            player = null;
        }
    }
}
