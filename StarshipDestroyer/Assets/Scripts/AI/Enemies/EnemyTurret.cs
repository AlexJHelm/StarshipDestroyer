using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationalDamp = .5f;
    public LayerMask aggroLayerMask;
    public Collider[] aggroColliders;
    //[SerializeField] Projectile shot;
    public EnemyProjectile projectilePrefab;
    public Transform muzzle;
    public float shotCooldown = 0.25f;
    public float aggroRadius = 40f;
    float shotDuration;
    float range = 1000f;

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
        Turn();

        if (aggroColliders.Length > 0)
        {
            target = aggroColliders[0].transform;
            if (CanFire)
            {
                FireProjectile();
            }
        }
    }

    void FireProjectile()
    {
        shotDuration = shotCooldown;
        Instantiate(projectilePrefab, muzzle.position, transform.rotation);
    }

    void Turn()
    {
        target = aggroColliders[0].transform;
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }
}
