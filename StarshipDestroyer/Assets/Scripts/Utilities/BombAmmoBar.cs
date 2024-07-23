using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombAmmoBar : MonoBehaviour
{
    public Slider ammoBar;
    public Bomb bombCooldown;
    private void Start()
    {
        bombCooldown = GameObject.FindGameObjectWithTag("Player").GetComponent<Bomb>();
        //healthBar = GetComponent<Slider>();
        ammoBar.maxValue = bombCooldown.maxBombCooldown;
        ammoBar.value = bombCooldown.bombCooldown;
    }
    public void Update()
    {
        ammoBar.value = bombCooldown.bombCooldown;
    }
}
