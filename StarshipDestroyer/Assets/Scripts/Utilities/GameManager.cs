using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variable Declaration

    public static GameManager GM { get; private set; }

    public EnemyMovement enemyPrefab;
    public BomberMovement bomberPrefab;
    public Transform enemyRespawnPos;

    public int enemyWeakpointsDestroyed = 0;
    public int allyWeakpointsDestroyed = 0;

    public bool canSpawn = true;

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
        StartCoroutine(RespawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn == true)
        {
            Instantiate(enemyPrefab, enemyRespawnPos.position, transform.rotation);
            Instantiate(bomberPrefab, enemyRespawnPos.position, transform.rotation);
            StartCoroutine(RespawnTimer());
        }

        //Win triggered if all enemy weakpoints are destroyed
        if(enemyWeakpointsDestroyed >= 3)
        {
            //Win Game
            SceneManager.LoadScene(3);
        }

        //Loss triggered if all ally weakpoints are destroyed
        if (allyWeakpointsDestroyed >= 3)
        {
            //Lose Game
            Debug.Log("You Lose...");
        }
    }

    public IEnumerator RespawnTimer()
    {
        canSpawn = false;
        yield return new WaitForSeconds(20f);
        canSpawn = true;
    }
}
