using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RespawnTimerScript : MonoBehaviour
{
    private TMP_Text timerText;
    private bool timerStarted;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.laserSystemActive == true)
        {
            if (GameObject.FindWithTag("PlayerLaser").GetComponent<ShipController>().respawnTimerActive == true)
            {
                timerStarted = true;
            }
        }
    }
}
