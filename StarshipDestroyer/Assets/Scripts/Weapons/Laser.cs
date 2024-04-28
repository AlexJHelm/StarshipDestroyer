using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    //Variable Declarations

    public PlayerProjectile projectilePrefab;
    public Transform muzzle;
    public float laserCooldown = 10f;
    public float laserDuration = 2f;
    float shotDuration;

    bool laserOffCooldown = true;
    bool laserActive = false;

    //Acts as a timer for the shot to last for
    bool CanFire
    {
        get
        {
            shotDuration -= Time.deltaTime;
            return shotDuration <= 0f;
        }
    }

    //Methods

    // Update is called once per frame
    void Update()
    {
        //Counts down the laser cooldown
        if(laserCooldown > 0f)
        {
            laserCooldown -= Time.deltaTime;
            laserOffCooldown = false;
        }

        //Sets the ability to use the laser to true once it is off cooldown
        else if(laserCooldown <= 0f)
        {
            laserOffCooldown = true;
        }

        /*Once the laser is off cooldown, can fire is true, and the right mouse button is clicked,
         the laser is fired and the duration begins to count down*/
        if(CanFire && laserOffCooldown && Input.GetMouseButton(1))
        { 
            laserDuration = 2f;
            laserActive = true;
            FireLaser();
            laserCooldown = 10f;
            laserOffCooldown = false;
        }

        //Continously fires projectiles while laser is active
        if(laserActive == true)
        {
            Instantiate(projectilePrefab, muzzle.position, transform.rotation);
            laserDuration -= Time.deltaTime;
        }

        //Stops the laser once the duration reaches 0 or less
        if(laserDuration <= 0)
        {
            laserActive = false;
        }
    }

    //Sets shot duration/range
    void FireLaser()
    {
        shotDuration = laserDuration;
    }
}
