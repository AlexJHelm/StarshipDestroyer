using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public AllyBombProjectile projectilePrefab;
    public Transform muzzle;
    public float maxBombCooldown = 10f;
    public float bombCooldown = 10f;
    public float Duration = 2f;
    float shotDuration;

    bool bombOffCooldown = true;

    //Acts as a timer for the shot to last for
    bool CanFire
    {
        get
        {
            shotDuration -= Time.deltaTime;
            return shotDuration <= 0f;
        }
    }

    //Methods

    // Update is called once per frame
    void Update()
    {
        //Counts down the bomb cooldown
        if (bombCooldown > 0f)
        {
            bombCooldown -= Time.deltaTime;
            bombOffCooldown = false;
        }

        //Sets the ability to use the bomb to true once it is off cooldown
        else if (bombCooldown <= 0f)
        {
            bombOffCooldown = true;
        }

        /*Once the bomb is off cooldown, can fire is true, and the right mouse button is clicked,
         the laser is fired and the duration begins to count down*/
        if (CanFire && bombOffCooldown && Input.GetMouseButton(1))
        {
            FireBomb();
            bombCooldown = maxBombCooldown;
            bombOffCooldown = false;
        }
    }

    //Sets shot duration/range
    void FireBomb()
    {
        Instantiate(projectilePrefab, muzzle.position, transform.rotation);
        shotDuration = Duration;
    }
}
