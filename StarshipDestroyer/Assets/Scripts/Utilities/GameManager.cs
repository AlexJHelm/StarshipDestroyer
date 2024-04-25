using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variable Declaration

    public int enemyWeakpointsDestroyed = 0;
    public int allyWeakpointsDestroyed = 0;

    //Methods

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
