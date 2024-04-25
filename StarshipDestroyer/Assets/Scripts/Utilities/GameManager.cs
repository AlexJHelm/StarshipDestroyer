using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variable Declaration

    public static GameManager GM { get; private set; }

    public int enemyWeakpointsDestroyed = 0;
    public int allyWeakpointsDestroyed = 0;

    int scrap;
    int maxShipUpgradeTotal;
    bool shipHealthUpgradeUnlocked, shipWeaponsUpgradeUnlocked;

    int currentlyAllocated, fightersAllocated, bombersAllocated, defendersAllocated;

    //Methods

    //Singleton to assign GameManager
    private void Awake()
    {
        if (GM != null && GM != this)
        {
            Destroy(this);
            return;
        }

        GM = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Win triggered if all enemy weakpoints are destroyed
        if(enemyWeakpointsDestroyed >= 3)
        {
            //Win Game
            Debug.Log("You Win!");
        }

        //Loss triggered if all ally weakpoints are destroyed
        if (allyWeakpointsDestroyed >= 3)
        {
            //Lose Game
            Debug.Log("You Lose...");
        }
    }
}
