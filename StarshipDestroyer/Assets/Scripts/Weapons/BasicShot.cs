using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShot : MonoBehaviour
{
    //Variable Declarations

    public PlayerProjectile projectilePrefab;
    public Transform muzzle;
    public float shotCooldown = 0.25f;
    float shotDuration;

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
        //Fires projectile if left mouse button is clicked
        if(CanFire && Input.GetMouseButton(0))
        {
            FireProjectile();
        }
    }

    //Sets shot duration and instantiates the shot
    void FireProjectile()
    {
        shotDuration = shotCooldown;
        Instantiate(projectilePrefab, muzzle.position, transform.rotation);
    }
}
