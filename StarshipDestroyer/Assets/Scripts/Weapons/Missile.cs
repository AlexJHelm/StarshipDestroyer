using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public PlayerProjectile projectilePrefab;
    public Transform muzzle1;
    public Transform muzzle2;
    public float maxMissileCooldown = 10f;
    public float missileCooldown = 10f;
    public float Duration = 2f;
    float shotDuration;

    bool missileOffCooldown = true;

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
        //Counts down the bomb cooldown
        if (missileCooldown > 0f)
        {
            missileCooldown -= Time.deltaTime;
            missileOffCooldown = false;
        }

        //Sets the ability to use the bomb to true once it is off cooldown
        else if (missileCooldown <= 0f)
        {
            missileOffCooldown = true;
        }

        /*Once the bomb is off cooldown, can fire is true, and the right mouse button is clicked,
         the laser is fired and the duration begins to count down*/
        if (CanFire && missileOffCooldown && Input.GetMouseButton(1))
        {
            FireMissile();
            missileCooldown = maxMissileCooldown;
            missileOffCooldown = false;
        }
    }

    //Sets shot duration/range
    void FireMissile()
    {
        Instantiate(projectilePrefab, muzzle1.position, transform.rotation);
        Instantiate(projectilePrefab, muzzle2.position, transform.rotation);
        shotDuration = Duration;
    }
}
