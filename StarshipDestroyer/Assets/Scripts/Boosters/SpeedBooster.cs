using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Trigger");
        Destroy(gameObject);
    }
}
