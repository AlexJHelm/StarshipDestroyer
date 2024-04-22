using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    //Variable Declaration


    //public and private variables for speeds and changing of speeds
    public float forwardSpeed = 25f, hoverSpeed = 5f, rollSpeed = 90f, rollAcceleration = 3.5f;
    private float activeForwardSpeed, activeHoverSpeed, rollInput;

    //private variables for acceleration
    private float forwardAcceleration = 2.5f, hoverAcceleration = 2.0f;

    //Variables for camera and mouse
    public float xLookRotateSpeed = 90f, yLookRotateSpeed = 180f; 
    private Vector2 lookInput, screenCenter, mouseDistance;

    //Strafe variables (not currently used)
    //public float strafeSpeed = 7.5f;
    //private float activeStrafeSpeed, strafeAcceleration = 2.0f;


    //Methods


    // Start is called before the first frame update
    void Start()
    {
        //Sets screen center
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        //Locks cursor to stay inside of screen
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
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
        transform.Rotate(mouseDistance.y * xLookRotateSpeed * Time.deltaTime, -mouseDistance.x * yLookRotateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        //Updates speed in each direction
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);
        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        //Moves ship
        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;

        //Strafe movement and speed updates (not currently used)
        //activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        //transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;
    }
}
