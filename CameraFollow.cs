using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed;
    public float minimumHeight;
    public float yDistance;
    public float zDistance;
    private Vector3 positionVelocity;


    private void FixedUpdate()
    {
        Vector3 chosenPosition = target.position + (target.forward * zDistance);
        chosenPosition.y = Mathf.Max(chosenPosition.y + yDistance, minimumHeight);

        Vector3 smoothedPositin = Vector3.SmoothDamp(transform.position, chosenPosition, ref positionVelocity, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPositin;

        Vector3 moveAndRotate = target.position + (target.forward * 5f);
        transform.LookAt(moveAndRotate);
    }
}
