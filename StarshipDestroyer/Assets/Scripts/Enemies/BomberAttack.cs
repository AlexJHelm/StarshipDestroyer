using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    //[SerializeField] Projectile shot;
    public BombProjectile bombPrefab;
    public Transform muzzle;
    public float shotCooldown = 5f;
    float shotDuration;
    float range = 500f;

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
        if (GameManager.GM.allyWeakpointsDestroyed == 0)
        {
            target = GameObject.FindWithTag("AllyThrusters").transform;
        }
        else if (GameManager.GM.allyWeakpointsDestroyed == 1)
        {
            target = GameObject.FindWithTag("AllyBridge").transform;
        }
        else
        {
            target = GameObject.FindWithTag("AllyWeapons").transform;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.GM.allyWeakpointsDestroyed == 0)
        {
            target = GameObject.FindWithTag("AllyThrusters").transform;
        }
        else if (GameManager.GM.allyWeakpointsDestroyed == 1)
        {
            target = GameObject.FindWithTag("AllyBridge").transform;
        }
        else
        {
            target = GameObject.FindWithTag("AllyWeapons").transform;
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
            if (hit.transform.CompareTag("AllyThrusters") || hit.transform.CompareTag("AllyBridge") || hit.transform.CompareTag("AllyWeapons"))
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
