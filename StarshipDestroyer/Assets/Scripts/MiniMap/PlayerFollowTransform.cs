using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerFollowTransform : MonoBehaviour
{
    public Transform target;
    public Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.laserSystemActive == true)
        {
            target = GameObject.FindWithTag("PlayerLaser").transform;
            transform.position = target.transform.position + Offset;
        }
        else if (GameManager.GM.bombSystemActive == true)
        {
            target = GameObject.FindWithTag("PlayerBomb").transform;
            transform.position = target.transform.position + Offset;
        }
        else if (GameManager.GM.missileSystemActive == true)
        {
            target = GameObject.FindWithTag("PlayerMissile").transform;
            transform.position = target.transform.position + Offset;
        }
    }
}
