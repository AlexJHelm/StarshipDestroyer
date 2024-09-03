using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAllocation : MonoBehaviour
{
    public void PlusFighter()
    {
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.currentlyAllocated + 1 <= GameManager.GM.numOfIncreasedShipAllocations + 5)
        {
            GameManager.GM.fightersAllocated += 1;
            GameManager.GM.currentlyAllocated += 1;
            GameManager.GM.remainingAllocationSlots -= 1;
        }

    }
    public void MinusFighter()
    {
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.currentlyAllocated - 1 >= 0)
        {
            if(GameManager.GM.fightersAllocated > 0)
            {
                GameManager.GM.fightersAllocated -= 1;
                GameManager.GM.currentlyAllocated -= 1;
                GameManager.GM.remainingAllocationSlots += 1;
            }           
        }

    }
    public void PlusBomber()
    {
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.currentlyAllocated + 1 <= GameManager.GM.numOfIncreasedShipAllocations + 5)
        {
            GameManager.GM.bombersAllocated += 1;
            GameManager.GM.currentlyAllocated += 1;
            GameManager.GM.remainingAllocationSlots -= 1;
        }

    }

    public void MinusBomber()
    {
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.currentlyAllocated - 1 >= 0)
        {
            if(GameManager.GM.bombersAllocated > 0)
            {
                GameManager.GM.bombersAllocated -= 1;
                GameManager.GM.currentlyAllocated -= 1;
                GameManager.GM.remainingAllocationSlots += 1;
            }
        }

    }

    public void PlusDefender()
    {
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.currentlyAllocated + 1 <= GameManager.GM.numOfIncreasedShipAllocations + 5)
        {
            GameManager.GM.defendersAllocated += 1;
            GameManager.GM.currentlyAllocated += 1;
            GameManager.GM.remainingAllocationSlots -= 1;
        }
    }

    public void MinusDefender()
    {
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.currentlyAllocated - 1 >= 0)
        {
            if(GameManager.GM.defendersAllocated > 0)
            {
                GameManager.GM.defendersAllocated -= 1;
                GameManager.GM.currentlyAllocated -= 1;
                GameManager.GM.remainingAllocationSlots += 1;
            }
        }
    }

    public void UnlockHealthUpgrade()
    {
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.scrap >= 25 && GameManager.GM.shipHealthUpgradeUnlocked == false)
        {
            GameManager.GM.scrap -= 25;
            GameManager.GM.shipHealthUpgradeUnlocked = true;

        }
    }

    public void UnlockSpacecraftUpgrade()
    {
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.scrap >= 25 && GameManager.GM.numOfIncreasedShipAllocations < 10)
        {
            GameManager.GM.scrap -= 25;
            GameManager.GM.numOfIncreasedShipAllocations += 1;
            GameManager.GM.remainingAllocationSlots = GameManager.GM.remainingAllocationSlots + 1;

        }
    }

    public void UnlockWeaponsUpgrade()
    {
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.scrap >= 25 && GameManager.GM.shipWeaponsUpgradeUnlocked == false)
        {
            GameManager.GM.scrap -= 25;
            GameManager.GM.shipWeaponsUpgradeUnlocked = true;
        }
    }

    public void LaserSystemActive()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.laserSystemActive = true;
        GameManager.GM.bombSystemActive = false;
        GameManager.GM.missileSystemActive = false;
    }

    public void BombSystemActive()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.laserSystemActive = false;
        GameManager.GM.bombSystemActive = true;
        GameManager.GM.missileSystemActive = false;
    }

    public void MissileSystemActive()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.laserSystemActive = false;
        GameManager.GM.bombSystemActive = false;
        GameManager.GM.missileSystemActive = true;
    }
}
