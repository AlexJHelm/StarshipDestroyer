using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBomberAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    //[SerializeField] Projectile shot;
    public AllyBombProjectile bombPrefab;
    public Transform muzzle;
    public float shotCooldown = 5f;
    float shotDuration;
    float range = 100f;

    bool CanFire
    {
        get
        {
            shotDuration -= Time.deltaTime;
            return shotDuration <= 0f;
        }
    }

    public void Start()
    {
        if (GameManager.GM.enemyWeakpointsDestroyed == 0)
        {
            target = GameObject.FindWithTag("EnemyThrusters").transform;
        }
        else if (GameManager.GM.enemyWeakpointsDestroyed == 1)
        {
            if (GameManager.GM.enemyThrustersDestroyed == false)
            {
                target = GameObject.FindWithTag("EnemyThrusters").transform;
            }
            else if (GameManager.GM.enemyBridgeDestroyed == false)
            {
                target = GameObject.FindWithTag("EnemyBridge").transform;
            }
        }
        else
        {
            if (GameManager.GM.enemyThrustersDestroyed == false)
            {
                target = GameObject.FindWithTag("EnemyThrusters").transform;
            }
            else if (GameManager.GM.enemyBridgeDestroyed == false)
            {
                target = GameObject.FindWithTag("EnemyBridge").transform;
            }
            else
            {
                target = GameObject.FindWithTag("EnemyWeapons").transform;
            }

        }
    }

    private void FixedUpdate()
    {
        if (GameManager.GM.enemyWeakpointsDestroyed == 0)
        {
            target = GameObject.FindWithTag("EnemyThrusters").transform;
        }
        else if (GameManager.GM.enemyWeakpointsDestroyed == 1)
        {
            if (GameManager.GM.enemyThrustersDestroyed == false)
            {
                target = GameObject.FindWithTag("EnemyThrusters").transform;
            }
            else if (GameManager.GM.enemyBridgeDestroyed == false)
            {
                target = GameObject.FindWithTag("EnemyBridge").transform;
            }
        }
        else
        {
            if (GameManager.GM.enemyThrustersDestroyed == false)
            {
                target = GameObject.FindWithTag("EnemyThrusters").transform;
            }
            else if (GameManager.GM.enemyBridgeDestroyed == false)
            {
                target = GameObject.FindWithTag("EnemyBridge").transform;
            }
            else
            {
                target = GameObject.FindWithTag("EnemyWeapons").transform;
            }

        }

        if (CanFire && InFront() && HaveLineOfSight())
        {
            Debug.Log("Bomber Shooting");
            FireProjectile();
        }
    }

    //Function to check if target is in front of game object
    bool InFront()
    {
        //Sets directions and angle
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        //Checks if the targets is in between 158 and 202 degrees infront of game object
        if (Mathf.Abs(angle) > 158 && Mathf.Abs(angle) < 202)
        {
            //Debug to visualize the angle
            Debug.DrawLine(transform.position, target.position, Color.green);
            return true;
        }

        //Debug to visualize the angle
        Debug.DrawLine(transform.position, target.position, Color.yellow);
        return false;
    }

    //Function to check if target is within line of sight of game object
    bool HaveLineOfSight()
    {
        //Creates the raycast and direction to target
        RaycastHit hit;
        Vector3 direction = target.position - transform.position;

        //Sends out raycast, and if it hits any of the weakpoints, return true, otherwise, return false
        if (Physics.Raycast(muzzle.position, direction, out hit, range))
        {
            if (hit.transform.CompareTag("EnemyThrusters") || hit.transform.CompareTag("EnemyBridge") || hit.transform.CompareTag("EnemyWeapons"))
            {
                return true;
            }
        }
        return false;
    }

    void FireProjectile()
    {
        shotDuration = shotCooldown;
        Instantiate(bombPrefab, muzzle.position, transform.rotation);
    }
}
