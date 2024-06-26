using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    public LayerMask aggroLayerMask;
    public Collider[] aggroColliders;
    //[SerializeField] Projectile shot;
    public EnemyProjectile projectilePrefab;
    public Transform muzzle;
    public float shotCooldown = 0.25f;
    public float aggroRadius = 40f;
    float shotDuration;
    float range = 3000f;

    bool CanFire
    {
        get
        {
            shotDuration -= Time.deltaTime;
            return shotDuration <= 0f;
        }
    }

    private void FixedUpdate()
    {
        //InFront();
        //HaveLineOfSight();

        aggroColliders = Physics.OverlapSphere(transform.position, aggroRadius, aggroLayerMask);

        if (aggroColliders.Length > 0)
        {
            target = aggroColliders[0].transform;
            transform.gameObject.GetComponent<DefenderMovement>().isChasing = true;
            if (CanFire && InFront() && HaveLineOfSight())
            {
                FireProjectile();
            }
        }
        else
        {
            transform.gameObject.GetComponent<DefenderMovement>().isChasing = false;
        }
    }

    bool InFront()
    {
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
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
            if (hit.transform.CompareTag("Player") || hit.transform.CompareTag("Ally") || hit.transform.CompareTag("AllyBomber") || hit.transform.CompareTag("AllyDefender"))
            {
                Debug.Log("Player Hit");
                return true;
            }
        }

        return false;
    }

    void FireProjectile()
    {
        shotDuration = shotCooldown;
        Instantiate(projectilePrefab, muzzle.position, transform.rotation);
    }
}
