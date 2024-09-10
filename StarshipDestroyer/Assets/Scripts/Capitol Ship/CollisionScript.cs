using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.tag == "CapitolShip" || collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Asteroid2" || collision.gameObject.tag == "Asteroid3" ||
            collision.gameObject.tag == "EnemyBridge" || collision.gameObject.tag == "EnemyWeapons" || collision.gameObject.tag == "EnemyThrusters" || collision.gameObject.tag == "AllyBridge" ||
            collision.gameObject.tag == "AllyyWeapons" || collision.gameObject.tag == "AllyThrusters")
        { 
            if(this.tag == "PlayerLaser" || this.tag == "PlayerBomb" || this.tag == "Playermissile")
            {
                gameObject.GetComponent<ShipController>().health = 0;
                Debug.Log("Destroyed");
            }
            else if (this.tag == "AllyBomber")
            {
                gameObject.GetComponent<AllyBomberMovement>().health = 0;
                Debug.Log("Destroyed");
            }
            else if (this.tag == "Ally")
            {
                gameObject.GetComponent<AllyMovement>().health = 0;
                Debug.Log("Destroyed");
            }
            else if (this.tag == "AllyDefender")
            {
                gameObject.GetComponent<AllyDefenderMovement>().health = 0;
                Debug.Log("Destroyed");
            }
            else if (this.tag == "EnemyBomber")
            {
                gameObject.GetComponent<BomberMovement>().health = 0;
                Debug.Log("Destroyed");
            }
            else if (this.tag == "Enemy")
            {
                gameObject.GetComponent<EnemyMovement>().health = 0;
                Debug.Log("Destroyed");
            }
            else if (this.tag == "EnemyDefender")
            {
                gameObject.GetComponent<DefenderMovement>().health = 0;
                Debug.Log("Destroyed");
            }

        }
    }
}
