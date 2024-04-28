using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    //Variable Declarations

    Rigidbody rb;
    float shotForce = 5000f;
    int damage = 10;
    float range = 3f;
    float duration;

    //Checks to see if projectile moves past it's range
    bool outOfRange
    {
        get
        {
            duration -= Time.deltaTime;
            return duration <= 0f;
        }
    }

    //Methods

    private void Awake()
    {
        //Assigns projectile rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        //Adds force and sets the projectiles range when it is active
        rb.AddForce(shotForce * transform.up);
        duration = range;
    }

    private void Update()
    {
        //Destroys game object if projectile moves out of range
        if(outOfRange)
        {
            Destroy(gameObject);
        }
    }

    //Collision Detection
    private void OnCollisionEnter(Collision collision)
    {
        //If it collides with an enemy weakpoint, deal damage and starting the invulnerability window, then destroy the projectile
        if(collision.gameObject.tag == "EnemyWeakpoint")
        {
            if (collision.gameObject.GetComponent<Weakpoints>().canTakeDamage == true)
            {
                collision.gameObject.GetComponent<Weakpoints>().takingDamage = true;
                collision.gameObject.GetComponent<Weakpoints>().weakpointHealth -= damage;           
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "CapitolShip")
        {
            Destroy(gameObject);
        }
        
    }
}
