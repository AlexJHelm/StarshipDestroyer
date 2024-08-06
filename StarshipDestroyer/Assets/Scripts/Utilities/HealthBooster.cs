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

    private void Update()
    {
        transform.Rotate(0, 1, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerLaser" || collision.gameObject.tag == "PlayerBomb" || collision.gameObject.tag == "PlayerMissile")
        {
            if(collision.gameObject.tag == "PlayerLaser")
            {
                if(GameObject.FindWithTag("PlayerLaser").GetComponent<ShipController>().health < GameObject.FindWithTag("PlayerLaser").GetComponent<ShipController>().maxHealth)
                {
                    GameObject.FindWithTag("PlayerLaser").GetComponent<ShipController>().health += 10;
                }             
                
            }
            else if (collision.gameObject.tag == "PlayerBomb")
            {
                if(GameObject.FindWithTag("PlayerBomb").GetComponent<ShipController>().health < GameObject.FindWithTag("PlayerBomb").GetComponent<ShipController>().maxHealth)
                {
                    GameObject.FindWithTag("PlayerBomb").GetComponent<ShipController>().health += 10;
                }
            }
            else if (collision.gameObject.tag == "PlayerMissile")
            {
                if(GameObject.FindWithTag("PlayerMissile").GetComponent<ShipController>().health < GameObject.FindWithTag("PlayerMissile").GetComponent<ShipController>().maxHealth)
                {
                    GameObject.FindWithTag("PlayerMissile").GetComponent<ShipController>().health += 10;
                }
            }
            Destroy(gameObject);

        }
    }
}
