using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAllocation : MonoBehaviour
{
    public void PlusFighter()
    {
        if (GameManager.GM.currentlyAllocated + 1 <= GameManager.GM.numOfIncreasedShipAllocations + 5)
        {
            GameManager.GM.fightersAllocated += 1;
            GameManager.GM.currentlyAllocated += 1;
            GameManager.GM.remainingAllocationSlots -= 1;
        }

    }
    public void MinusFighter()
    {
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
        if (GameManager.GM.currentlyAllocated + 1 <= GameManager.GM.numOfIncreasedShipAllocations + 5)
        {
            GameManager.GM.bombersAllocated += 1;
            GameManager.GM.currentlyAllocated += 1;
            GameManager.GM.remainingAllocationSlots -= 1;
        }

    }

    public void MinusBomber()
    {
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
        if (GameManager.GM.currentlyAllocated + 1 <= GameManager.GM.numOfIncreasedShipAllocations + 5)
        {
            GameManager.GM.defendersAllocated += 1;
            GameManager.GM.currentlyAllocated += 1;
            GameManager.GM.remainingAllocationSlots -= 1;
        }
    }

    public void MinusDefender()
    {
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
}
