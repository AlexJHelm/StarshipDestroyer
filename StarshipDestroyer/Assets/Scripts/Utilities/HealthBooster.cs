using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBooster : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        //Assigns projectile rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerLaser" || collision.gameObject.tag == "PlayerBomb" || collision.gameObject.tag == "PlayerMissile")
        {
            if(collision.gameObject.tag == "PlayerLaser")
            {
                GameObject.FindWithTag("PlayerLaser").GetComponent<ShipController>().health += 10;
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "PlayerBomb")
            {
                GameObject.FindWithTag("PlayerBomb").GetComponent<ShipController>().health += 10;
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "PlayerMissile")
            {
                GameObject.FindWithTag("PlayerMissile").GetComponent<ShipController>().health += 10;
                Destroy(gameObject);
            }

        }
    }
}
