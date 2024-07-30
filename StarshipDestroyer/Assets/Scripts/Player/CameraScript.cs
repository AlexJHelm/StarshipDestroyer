using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public float followSpeed = 2f;
    public float turnDampening = 0.1f;

    public Vector3 cameraOffset = new Vector3(0,5,-10);

    public Vector3 minCameraBounds = new Vector3(-50,10,-50);
    public Vector3 maxCameraBounds = new Vector3(50,50,50);

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position + player.transform.rotation * cameraOffset;

        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, followSpeed * Time.deltaTime);

        smoothedPosition = new Vector3(
            Mathf.Clamp(smoothedPosition.x, minCameraBounds.x, maxCameraBounds.x),
            Mathf.Clamp(smoothedPosition.y, minCameraBounds.y, maxCameraBounds.y),
            Mathf.Clamp(smoothedPosition.z, minCameraBounds.z, maxCameraBounds.z));
        
        transform.position = smoothedPosition;

        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnDampening * Time.deltaTime);
    }



}
