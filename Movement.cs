using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float wMovement;
    public float rotating;
    public float rotationRate;
    public float turnRotationSeekSpeed;
    public Transform tr;

    private float groundAngelVelocity;
    private float rotationVelocity;

    void Start()
    {
        Debug.Log("Works");
    }

    void FixedUpdate()
    {
        //This rotates the car at Y axis
        Vector3 turnSmooth = Vector3.up * rotationRate * Input.GetAxis("Horizontal");
        turnSmooth = turnSmooth * Time.deltaTime * rb.mass;
        rb.AddTorque(turnSmooth);

        //This makes a illusion of the rotation it only rotates the car but Z axis
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") * -rotating, ref rotationVelocity, turnRotationSeekSpeed);
        transform.eulerAngles = newRotation;

        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.forward * wMovement * 3);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(transform.forward * wMovement * -3);
        }

        if (Input.GetKey("space"))
        {
            transform.Rotate(new Vector3(-1, 0, 0) * 2f);
        }
    }
}
