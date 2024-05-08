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
            target = GameObject.FindWithTag("EnemyBridge").transform;
        }
        else
        {
            target = GameObject.FindWithTag("EnemyWeapons").transform;
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
            target = GameObject.FindWithTag("EnemyBridge").transform;
        }
        else
        {
            target = GameObject.FindWithTag("EnemyWeapons").transform;
        }

        if (CanFire && InFront() && HaveLineOfSight())
        {
            Debug.Log("Bomber Shooting");
            FireProjectile();
        }
    }

    bool InFront()
    {
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (Mathf.Abs(angle) > 158 && Mathf.Abs(angle) < 202)
        {
            Debug.DrawLine(transform.position, target.position, Color.green);
            return true;
        }

        Debug.DrawLine(transform.position, target.position, Color.yellow);
        return false;
    }

    bool HaveLineOfSight()
    {
        RaycastHit hit;

        Vector3 direction = target.position - transform.position;
        //Debug.DrawRay(shot.transform.position, direction, Color.red);

        if (Physics.Raycast(muzzle.position, direction, out hit, range))
        {
            if (hit.transform.CompareTag("EnemyThrusters") || hit.transform.CompareTag("EnemyBridge") || hit.transform.CompareTag("EnemyWeapons"))
            {
                Debug.Log("Bomber has LoS");
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
