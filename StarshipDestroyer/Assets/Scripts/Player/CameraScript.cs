using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // The ship we're following
    private GameObject targetShip;
    // Keep track of past positions and rotations for that smooth laggy feel
    private Queue<Vector3> prevPositions = new Queue<Vector3>();
    private Queue<Quaternion> prevRotations = new Queue<Quaternion>();

    // How many frames behind we want the camera to be
    public float cameraLag = 10f;
    // Where the camera should be relative to the ship (like, behind and above it)
    public Vector3 thirdPersonOffset = new Vector3(0.0f, 5.0f, -10.0f);
    // How slowly the camera should move to new positions
    public float positionSmoothSpeed = 0.05f;
    // How slowly the camera should rotate to new angles
    public float rotationSmoothSpeed = 0.05f;

    void Start()
    {
        if(GameManager.GM.laserSystemActive == true)
        {
            // Find the ship the camera should follow
            targetShip = GameObject.FindWithTag("PlayerLaser").gameObject;
            /*// Detach the camera from the ship so it can move independently
            transform.parent = null;*/
        }
        else if (GameManager.GM.bombSystemActive == true)
        {
            // Find the ship the camera should follow
            targetShip = GameObject.FindWithTag("PlayerBomb").gameObject;
            /*// Detach the camera from the ship so it can move independently
            transform.parent = null;*/
        }
        else if (GameManager.GM.missileSystemActive == true)
        {
            // Find the ship the camera should follow
            targetShip = GameObject.FindWithTag("PlayerMissile").gameObject;
            /*// Detach the camera from the ship so it can move independently
            transform.parent = null;*/
        }
    }

    void FixedUpdate()
    {
        // Add the current position and rotation of the ship to our history queues
        prevPositions.Enqueue(targetShip.transform.position);
        prevRotations.Enqueue(targetShip.transform.rotation);

        // Check if the ship is slowing down
        bool isSlowingDown = targetShip.GetComponent<ShipController>().isSlowingDown;
        bool isSpeedingUp = targetShip.GetComponent<ShipController>().isSpeedingUp;

        Vector3 normalOffset = thirdPersonOffset;

        Vector3 slowingDownOffset = new Vector3(thirdPersonOffset.x, thirdPersonOffset.y, thirdPersonOffset.z - 10f);
        Vector3 speedingUpOffset = new Vector3(thirdPersonOffset.x, thirdPersonOffset.y, thirdPersonOffset.z + 10f);

        Vector3 dynamicOffset;

        if (isSlowingDown)
        {
            dynamicOffset = Vector3.Lerp(normalOffset, slowingDownOffset, 0.5f); // Transition when slowing down
        }
        else if (isSpeedingUp)
        {
            dynamicOffset = Vector3.Lerp(normalOffset, speedingUpOffset, 0.3f); // Transition when speeding up
        }
        else
        {
            dynamicOffset = normalOffset; // Default offset
        }

        // If we have more than the desired amount of history, start using the oldest data
        if (prevPositions.Count > cameraLag)
        {
            // Get the old position and rotation from the queues
            Vector3 desiredPosition = prevPositions.Dequeue() + targetShip.transform.TransformDirection(dynamicOffset);
            Quaternion desiredRotation = prevRotations.Dequeue();

            // Smoothly move the camera to the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, positionSmoothSpeed);
            // Smoothly rotate the camera to the desired rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed);
        }
        else
        {
            // If we don't have enough history yet, just follow the ship normally
            Vector3 desiredPosition = targetShip.transform.position + targetShip.transform.TransformDirection(thirdPersonOffset);
            Quaternion desiredRotation = targetShip.transform.rotation;

            // Smoothly move the camera to the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, positionSmoothSpeed);
            // Smoothly rotate the camera to the desired rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed);
        }
    }
}