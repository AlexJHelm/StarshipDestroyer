using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Variable Declaration

    public static GameManager GM { get; private set; }

    public GameObject playerMissile;
    public GameObject playerLaser;
    public GameObject playerBomb;
    public EnemyMovement enemyPrefab;
    public BomberMovement bomberPrefab;
    public DefenderMovement defenderPrefab;
    public AllyMovement allyPrefab;
    public AllyBomberMovement allyBomberPrefab;
    public AllyDefenderMovement allyDefenderPrefab;
    public Asteroid asteroid1;
    public Asteroid asteroid2;
    public Asteroid asteroid3;
    public Transform enemyRespawnPos1;
    public Transform enemyRespawnPos2;
    public Transform enemyRespawnPos3;
    public Transform allyRespawnPos1;
    public Transform allyRespawnPos2;
    public Transform allyRespawnPos3;

    public int enemyWeakpointsDestroyed = 0;
    public int allyWeakpointsDestroyed = 0;

    public bool enemyWeaponsDestroyed;
    public bool enemyBridgeDestroyed;
    public bool enemyThrustersDestroyed;

    public bool inGame = false;
    public bool inSetup = false;
    public bool shipSelected = false;

    public bool canSpawn = true;
    public bool asteroidCanSpawn = true;

    public int scrap = 30;
    int randomSpawnX, randomSpawnY, randomSpawnZ, randomSpawnPos, randomAsteroidNum;
    public int numOfIncreasedShipAllocations = 1;
    public int remainingAllocationSlots;
    public bool shipHealthUpgradeUnlocked, shipWeaponsUpgradeUnlocked;

    public bool laserSystemActive, bombSystemActive, missileSystemActive;

    public int currentlyAllocated, fightersAllocated, bombersAllocated, defendersAllocated = 0;

    public int fightersAlive, bombersAlive, defendersAlive, enemyFightersAlive, enemyBombersAlive, enemyDefendersAlive = 0;

    public int maxFighters, maxBombers, maxDefenders;

    public TMP_Text fighterText, bomberText, defenderText, remainingText, scrapText, healthUpgradeText, spacecraftUpgradeText, weaponsUpgradeText, laserText, bombText, missileText;

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
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        remainingAllocationSlots = numOfIncreasedShipAllocations + 5;

        if (inGame == true)
        {
            playerLaser = GameObject.FindWithTag("PlayerLaser");
            playerBomb = GameObject.FindWithTag("PlayerBomb");
            playerMissile = GameObject.FindWithTag("PlayerMissile");

            if (laserSystemActive == true)
            {
                playerLaser.SetActive(true);
                playerBomb.SetActive(false);
                playerMissile.SetActive(false);
            }
            else if (bombSystemActive == true)
            {
                playerLaser.SetActive(false);
                playerBomb.SetActive(true);
                playerMissile.SetActive(false);
            }
            else if (missileSystemActive == true)
            {
                playerLaser.SetActive(false);
                playerBomb.SetActive(false);
                playerMissile.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inGame == true)
        {
            enemyRespawnPos1 = GameObject.FindWithTag("EnemyRespawnPos1").transform;
            allyRespawnPos1 = GameObject.FindWithTag("RespawnPos1").transform;
            enemyRespawnPos2 = GameObject.FindWithTag("EnemyRespawnPos2").transform;
            allyRespawnPos2 = GameObject.FindWithTag("RespawnPos2").transform;
            enemyRespawnPos3 = GameObject.FindWithTag("EnemyRespawnPos3").transform;
            allyRespawnPos3 = GameObject.FindWithTag("RespawnPos3").transform;

            playerLaser = GameObject.FindWithTag("PlayerLaser");
            playerBomb = GameObject.FindWithTag("PlayerBomb");
            playerMissile = GameObject.FindWithTag("PlayerMissile");

            if (laserSystemActive == true && shipSelected == false)
            {
                playerLaser.SetActive(true);
                playerBomb.SetActive(false);
                playerMissile.SetActive(false);
                shipSelected = true;
            }
            else if (bombSystemActive == true && shipSelected == false)
            {
                playerLaser.SetActive(false);
                playerBomb.SetActive(true);
                playerMissile.SetActive(false);
                shipSelected = true;
            }
            else if (missileSystemActive == true && shipSelected == false)
            {
                playerLaser.SetActive(false);
                playerBomb.SetActive(false);
                playerMissile.SetActive(true);
                shipSelected = true;
            }

            if (canSpawn == true)
            {
                while(enemyFightersAlive < maxFighters)
                {
                    randomSpawnPos = Random.Range(0, 4);
                    if(randomSpawnPos <= 1)
                    {
                        Instantiate(enemyPrefab, enemyRespawnPos1.position, transform.rotation);
                    }
                    else if(randomSpawnPos > 1 && randomSpawnPos <= 2)
                    {
                        Instantiate(enemyPrefab, enemyRespawnPos2.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(enemyPrefab, enemyRespawnPos3.position, transform.rotation);
                    }
                    
                    enemyFightersAlive += 1;
                }

                while (enemyBombersAlive < maxBombers)
                {
                    randomSpawnPos = Random.Range(0, 4);
                    if (randomSpawnPos <= 1)
                    {
                        Instantiate(bomberPrefab, enemyRespawnPos1.position, transform.rotation);
                    }
                    else if (randomSpawnPos > 1 && randomSpawnPos <= 2)
                    {
                        Instantiate(bomberPrefab, enemyRespawnPos2.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(bomberPrefab, enemyRespawnPos3.position, transform.rotation);
                    }
                    enemyBombersAlive += 1;
                }

                while (enemyDefendersAlive < maxDefenders)
                {
                    randomSpawnPos = Random.Range(0, 4);
                    if (randomSpawnPos <= 1)
                    {
                        Instantiate(defenderPrefab, enemyRespawnPos1.position, transform.rotation);
                    }
                    else if (randomSpawnPos > 1 && randomSpawnPos <= 2)
                    {
                        Instantiate(defenderPrefab, enemyRespawnPos2.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(defenderPrefab, enemyRespawnPos3.position, transform.rotation);
                    }
                    enemyDefendersAlive += 1;
                }

                while (fightersAlive < maxFighters)
                {
                    randomSpawnPos = Random.Range(0, 4);
                    if (randomSpawnPos <= 1)
                    {
                        Instantiate(allyPrefab, allyRespawnPos1.position, transform.rotation);
                    }
                    else if (randomSpawnPos > 1 && randomSpawnPos <= 2)
                    {
                        Instantiate(allyPrefab, allyRespawnPos2.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(allyPrefab, allyRespawnPos3.position, transform.rotation);
                    }
                    fightersAlive += 1;
                }

                while (bombersAlive < maxBombers)
                {
                    randomSpawnPos = Random.Range(0, 4);
                    if (randomSpawnPos <= 1)
                    {
                        Instantiate(allyBomberPrefab, allyRespawnPos1.position, transform.rotation);
                    }
                    else if (randomSpawnPos > 1 && randomSpawnPos <= 2)
                    {
                        Instantiate(allyBomberPrefab, allyRespawnPos2.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(allyBomberPrefab, allyRespawnPos3.position, transform.rotation);
                    }
                    bombersAlive += 1;
                }

                while (defendersAlive < maxDefenders)
                {
                    randomSpawnPos = Random.Range(0, 4);
                    if (randomSpawnPos <= 1)
                    {
                        Instantiate(allyDefenderPrefab, allyRespawnPos1.position, transform.rotation);
                    }
                    else if (randomSpawnPos > 1 && randomSpawnPos <= 2)
                    {
                        Instantiate(allyDefenderPrefab, allyRespawnPos2.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(allyDefenderPrefab, allyRespawnPos3.position, transform.rotation);
                    }
                    defendersAlive += 1;
                }               
                StartCoroutine(RespawnTimer());
                
            }
            if (asteroidCanSpawn == true)
            {
                randomSpawnX = Random.Range(-250, 380);
                randomSpawnY = Random.Range(-50, 140);
                randomSpawnZ = Random.Range(-290, 50);
                randomAsteroidNum = Random.Range(0, 4);
                if (randomAsteroidNum <= 1)
                {
                    Instantiate(asteroid1, new Vector3(randomSpawnX, randomSpawnY, randomSpawnZ), transform.rotation);
                }
                else if(randomAsteroidNum > 1 && randomAsteroidNum <= 2)
                {
                    Instantiate(asteroid2, new Vector3(randomSpawnX, randomSpawnY, randomSpawnZ), transform.rotation);
                }
                else
                {
                    Instantiate(asteroid3, new Vector3(randomSpawnX, randomSpawnY, randomSpawnZ), transform.rotation);
                }
                                   
                StartCoroutine(AsteroidTimer());
            }

            //Win triggered if all enemy weakpoints are destroyed
            if (enemyWeakpointsDestroyed >= 3)
            {
                //Win Game
                SceneManager.LoadScene(3);
                inGame = false;
            }

            //Loss triggered if all ally weakpoints are destroyed
            if (allyWeakpointsDestroyed >= 3)
            {
                //Lose Game
                SceneManager.LoadScene(4);
                inGame = false;
            }
        }
        
        if(inSetup == true)
        {        
            remainingText = GameObject.FindWithTag("RemainingText").GetComponent<TMP_Text>();
            fighterText = GameObject.FindWithTag("FighterText").GetComponent<TMP_Text>();
            bomberText = GameObject.FindWithTag("BomberText").GetComponent<TMP_Text>();
            defenderText = GameObject.FindWithTag("DefenderText").GetComponent<TMP_Text>();
            scrapText = GameObject.FindWithTag("ScrapCount").GetComponent<TMP_Text>();
            healthUpgradeText = GameObject.FindWithTag("HealthUpgradeText").GetComponent<TMP_Text>();
            weaponsUpgradeText = GameObject.FindWithTag("WeaponsUpgradeText").GetComponent<TMP_Text>();
            spacecraftUpgradeText = GameObject.FindWithTag("SpacecraftUpgradeText").GetComponent<TMP_Text>();
            laserText = GameObject.FindWithTag("LaserText").GetComponent<TMP_Text>();
            bombText = GameObject.FindWithTag("BombText").GetComponent<TMP_Text>();
            missileText = GameObject.FindWithTag("MissileText").GetComponent<TMP_Text>();

            remainingText.text = $"Remaining: {remainingAllocationSlots}";
            fighterText.text = $"{fightersAllocated}";
            bomberText.text = $"{bombersAllocated}";
            defenderText.text = $"{defendersAllocated}";
            scrapText.text = $"{scrap} Scrap";
            if(shipHealthUpgradeUnlocked == true)
            {
                healthUpgradeText.text = "Unlocked";
            }
            if (shipWeaponsUpgradeUnlocked == true)
            {
                weaponsUpgradeText.text = "Unlocked";
            }
            if (numOfIncreasedShipAllocations >= 10)
            {
                spacecraftUpgradeText.text = "Unlocked";
            }
            if(laserSystemActive == true)
            {
                laserText.text = "Selected";
                bombText.text = "Select";
                missileText.text = "Select";
            }
            if (bombSystemActive == true)
            {
                laserText.text = "Select";
                bombText.text = "Selected";
                missileText.text = "Select";
            }
            if (missileSystemActive == true)
            {
                laserText.text = "Select";
                bombText.text = "Select";
                missileText.text = "Selected";
            }
        }

        if(inGame == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public IEnumerator RespawnTimer()
    {
        canSpawn = false;
        yield return new WaitForSeconds(30f);
        canSpawn = true;
    }
    public IEnumerator AsteroidTimer()
    {
        asteroidCanSpawn = false;
        yield return new WaitForSeconds(5f);
        asteroidCanSpawn = true;
    }  
}
