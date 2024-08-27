using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.tag == "CapitolShip" || collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Asteroid2" || collision.gameObject.tag == "Asteroid3")
        {
            gameObject.GetComponent<ShipController>().health = 0;
            Debug.Log("Destroyed");
        }
    }
}
