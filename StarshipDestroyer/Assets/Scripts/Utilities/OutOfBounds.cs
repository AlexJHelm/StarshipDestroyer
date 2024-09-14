using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerLaser" || other.gameObject.tag == "PlayerBomb" || other.gameObject.tag == "PlayerMissiles")
        {
            other.gameObject.GetComponent<ShipController>().health = 0;
        }
    }
}
