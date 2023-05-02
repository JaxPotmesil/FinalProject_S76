using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 inputPM;
    public Rigidbody rigidB;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    public float maxacel;
    public GameObject gun;
    public GameObject gunNormal;
    public GameObject gunSprint;

    // Start is called before the first frame update
    void Start()
    {
        inputPM = new Vector2();
       
    }

    // Update is called once per frame
    void Update()
    {
        //rigidB.AddForce(transform.localToWorldMatrix * new Vector3(inputPM.x, 0, inputPM.y) * speed);
        Vector3 targetVelo = transform.localToWorldMatrix * new Vector3(inputPM.x, 0, inputPM.y) * speed;
        Vector3 veloChange = targetVelo - new Vector3(rigidB.velocity.x, 0, rigidB.velocity.z);
        rigidB.AddForce(Vector3.ClampMagnitude(veloChange, maxacel), ForceMode.Acceleration);
    }
    public void GetMovementInput(InputAction.CallbackContext context)
    {
        inputPM = context.ReadValue<Vector2>();
    }

    public void GetSprintInput(InputAction.CallbackContext sprintCon)
    {
        if (sprintCon.performed)
        {
            speed = runSpeed;
            gun.transform.parent = gunSprint.transform;
            gun.transform.localPosition = Vector3.zero;
            gun.transform.localRotation = Quaternion.identity;
        }
        else if (sprintCon.canceled)
        {
            speed = walkSpeed;
            gun.transform.parent = gunNormal.transform;
            gun.transform.localPosition = Vector3.zero;
            gun.transform.localRotation = Quaternion.identity;
        }
    }

    public void getShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            speed = walkSpeed;
            gun.transform.parent = gunNormal.transform;
            gun.transform.localPosition = Vector3.zero;
            gun.transform.localRotation = Quaternion.identity;
        }
    }
}
