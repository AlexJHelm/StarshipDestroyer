using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.gameObject.tag == "PlayerLaser" || other.gameObject.tag == "PlayerBomb" || other.gameObject.tag == "PlayerMissile")
        {
            other.gameObject.GetComponent<ShipController>().health = 0;
            Debug.Log("Destroyed");
        }
    }
}
