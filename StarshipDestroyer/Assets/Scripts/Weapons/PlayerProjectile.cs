using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    //Variable Declarations

    Rigidbody rb;
    float shotForce = 5000f;
    public int damage = 10;
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
        if (GameManager.GM.shipWeaponsUpgradeUnlocked == true)
        {
            damage = damage * 2;
        }
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
        if(outOfRange)
        {
            Destroy(gameObject);
        }
    }

    //Collision Detection
    private void OnCollisionEnter(Collision collision)
    {
        //If it collides with an enemy weakpoint, deal damage and starting the invulnerability window, then destroy the projectile
        if(collision.gameObject.tag == "EnemyThrusters" || collision.gameObject.tag == "EnemyBridge" || collision.gameObject.tag == "EnemyWeapons")
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

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyMovement>().health -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyBomber")
        {
            collision.gameObject.GetComponent<BomberMovement>().health -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyDefender")
        {
            collision.gameObject.GetComponent<DefenderMovement>().health -= damage;
            Destroy(gameObject);
        }

    }
}
