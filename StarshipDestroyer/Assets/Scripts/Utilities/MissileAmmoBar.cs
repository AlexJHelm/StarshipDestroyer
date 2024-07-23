using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileAmmoBar : MonoBehaviour
{
    public Slider ammoBar;
    public Missile missileCooldown;
    private void Start()
    {
        missileCooldown = GameObject.FindGameObjectWithTag("Player").GetComponent<Missile>();
        //healthBar = GetComponent<Slider>();
        ammoBar.maxValue = missileCooldown.maxMissileCooldown;
        ammoBar.value = missileCooldown.missileCooldown;
    }
    public void Update()
    {
        ammoBar.value = missileCooldown.missileCooldown;
    }
}
