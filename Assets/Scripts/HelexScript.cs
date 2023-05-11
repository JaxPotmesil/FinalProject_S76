using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelexScript : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("walls"))
        {
            Destroy(gameObject);
        }
    }
}
