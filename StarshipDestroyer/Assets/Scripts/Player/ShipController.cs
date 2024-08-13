using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    //Variable Declaration


    //public and private variables for speeds and changing of speeds
    public float hoverSpeed = 5f, rollSpeed = 90f, rollAcceleration = 3.5f, boostSpeed = 25f, baseForwardSpeed, boosterTimer, maxBoosterTimer = 10f;
    private float activeForwardSpeed, activeHoverSpeed, rollInput;

    public int maxHealth = 100;
    public int health;
    public Vector3 respawnPos;
    public Camera mainCamera;
    public Camera overlookCamera;

    public float deadZoneRadius = .10f;
    public float mouseSensitivity = 1.0f;

    //private variables for acceleration
    private float forwardAcceleration = 2.5f, hoverAcceleration = 2.0f, forwardSpeed = 25f;

    public float rotationSmoothSpeed = 0.1f; // Smooth speed for weighty feel

    //Variables for camera and mouse
    public float xLookRotateSpeed = 90f, yLookRotateSpeed = 180f; 
    private Vector2 lookInput, screenCenter, mouseDistance;

    private Quaternion targetRotation;

    public bool boosterActive, ammoBoosterActive = false;

    //Strafe variables (not currently used)
    //public float strafeSpeed = 7.5f;
    //private float activeStrafeSpeed, strafeAcceleration = 2.0f;

    public MeshRenderer mesh;
    Rigidbody rb;

    //Methods


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera.enabled = true;
        overlookCamera.enabled = false;
        targetRotation = transform.rotation;

        //Sets screen center
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        health = maxHealth;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health > 0)
        {
            // Mouse control for pitch and yaw
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            //Updates location of mouse
            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;

            //Tracks distance mouse traveled in frame 
            mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
            mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

            //Clamps the magnitude of change in mouse distance
            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 0.5f);

            //Rotates ship based on x, y, and z speeds and mouse movements
            if(-mouseDistance.y > -deadZoneRadius && -mouseDistance.y < deadZoneRadius && mouseDistance.x < deadZoneRadius && mouseDistance.x > -deadZoneRadius)
            {
                transform.Rotate(-mouseDistance.y * xLookRotateSpeed/2 * Time.deltaTime, mouseDistance.x * yLookRotateSpeed/2 * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);
            }
            else
            {
                transform.Rotate(-mouseDistance.y * xLookRotateSpeed * Time.deltaTime, mouseDistance.x * yLookRotateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);
            }

            //Moves ship
            if (boosterActive == true)
            {
                forwardSpeed = boostSpeed;
                boosterTimer += 1;
                hoverSpeed = 30f;
            }
            else
            {
                forwardSpeed = baseForwardSpeed;
                hoverSpeed = 15f;
                boosterTimer = maxBoosterTimer;
            }

            //Updates speed in each direction
            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
            activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);
            rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

            /*if(Input.GetKeyDown(KeyCode.W))
            {
                activeForwardSpeed = Input.GetAxisRaw("Vertical") * forwardSpeed * Time.deltaTime;
            }
            else
            {
                activeForwardSpeed = 0;
            }*/

            //transform.position = Vector3.Lerp(transform.position, desiredPosition, positionSmoothSpeed);
            transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;

            /*
            // Adjust target rotation based on mouse input
            targetRotation *= Quaternion.Euler(-mouseY, mouseX, 0);

            // Smoothly interpolate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothSpeed);
            */

            //transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
            //rb.AddForce(transform.forward * activeForwardSpeed, ForceMode.Impulse);

            //Strafe movement and speed updates (not currently used)
            //activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
            //transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;
        }

        else
        {
            mesh.enabled = false;
            mainCamera.enabled = false;
            overlookCamera.enabled = true;
            StartCoroutine(RespawnTimer());
        }
    }

    public IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(3f);
        health = 100;
        overlookCamera.enabled = false;
        mainCamera.enabled = true;
        transform.position = respawnPos;
        mesh.enabled = true;

    }

    public IEnumerator BoosterTimer()
    {
        yield return new WaitForSeconds(10f);
        boosterActive = false;
    }

    public void StartBoosterTimer()
    {
        StartCoroutine(BoosterTimer());
    }

    public IEnumerator AmmoBoosterTimer()
    {
        yield return new WaitForSeconds(10f);
        ammoBoosterActive = false;
    }

    public void StartAmmoBoosterTimer()
    {
        StartCoroutine(AmmoBoosterTimer());
    }
}
