using System.Collections;
using System.Collections.Generic;
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

    //private variables for acceleration
    private float forwardAcceleration = 2.5f, hoverAcceleration = 2.0f, forwardSpeed = 25f;

    //Variables for camera and mouse
    public float xLookRotateSpeed = 90f, yLookRotateSpeed = 180f; 
    private Vector2 lookInput, screenCenter, mouseDistance;

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

        //Sets screen center
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0)
        {
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

            transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
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
