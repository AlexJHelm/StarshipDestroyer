using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    Rigidbody rb;
    float shotForce = 500f;
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
        rb.AddForce(shotForce * transform.forward);
        duration = range;
    }

    private void Update()
    {
        //Destroys game object if projectile moves out of range
        if (outOfRange)
        {
            Destroy(gameObject);
        }
    }

    //Collision Detection
    private void OnCollisionEnter(Collision collision)
    {
        //If it collides with an enemy weakpoint, deal damage and starting the invulnerability window, then destroy the projectile
        if (collision.gameObject.tag == "AllyThrusters" || collision.gameObject.tag == "AllyBridge" || collision.gameObject.tag == "AllyWeapons")
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

        if (collision.gameObject.tag == "PlayerLaser" || collision.gameObject.tag == "PlayerBomb" || collision.gameObject.tag == "PlayerMissile")
        {
            collision.gameObject.GetComponent<ShipController>().health -= damage;
            Destroy(gameObject);
        }

    }
}
