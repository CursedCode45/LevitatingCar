using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    public float thrustersForce = 10;
    public float maxDistance = 3f;
    public Rigidbody rb;
    public Transform[] thrusters;
    Vector3 downForce;

    void FixedUpdate()
    {
        RaycastHit hit;

        foreach (Transform thruster in thrusters)
        {
            Vector3 downForce;
            float distancePercentage;

            if (Physics.Raycast(thruster.position, thruster.up*-1, out hit, maxDistance))
            {
                distancePercentage = 1 - (hit.distance / maxDistance);
                downForce = transform.up * thrustersForce * Time.deltaTime * rb.mass * distancePercentage;
                rb.AddForceAtPosition(downForce, thruster.position);
                Debug.DrawRay(thruster.position, thruster.up * -1 * maxDistance, Color.green);
                rb.drag = 2f;
            }
            else
            {
                rb.drag = 0.5f;
            }
        }

    }
}
