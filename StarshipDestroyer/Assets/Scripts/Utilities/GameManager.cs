using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    public Vector2 hotSpot = Vector2.zero;

    public int enemyWeakpointsDestroyed = 0;
    public int allyWeakpointsDestroyed = 0;

    public bool enemyWeaponsDestroyed;
    public bool enemyBridgeDestroyed;
    public bool enemyThrustersDestroyed;
    public bool cutscenePlaying;

    public bool inGame = false;
    public bool inSetup = false;
    public bool shipSelected = false;
    public bool menuMusicPlaying = true;

    public bool canSpawn = true;
    public bool asteroidCanSpawn = true;

    public int scrap = 30;
    int randomSpawnX, randomSpawnY, randomSpawnZ, randomSpawnPos, randomAsteroidNum;
    public int numOfIncreasedShipAllocations = 0;
    public int remainingAllocationSlots;
    public bool shipHealthUpgradeUnlocked, shipWeaponsUpgradeUnlocked, onUpgradeScreen, onWeaponsScreen, onLaunchScreen, onWinScene;

    public bool laserSystemActive, bombSystemActive, missileSystemActive;

    public int currentlyAllocated, fightersAllocated, bombersAllocated, defendersAllocated = 0;

    public int fightersAlive, bombersAlive, defendersAlive, enemyFightersAlive, enemyBombersAlive, enemyDefendersAlive = 0;

    public int maxFighters, maxBombers, maxDefenders;

    public int scrapGained, fightersDestroyed, bombersDestroyed, defendersDestroyed, totalDestroyed, numOfAsteroids;

    public TMP_Text fighterText, bomberText, defenderText, remainingText, scrapText, healthUpgradeText, spacecraftUpgradeText, weaponsUpgradeText, laserText, bombText, missileText, 
        shipsAllocatedText, selectedWeaponText, confirmationText, fightersDestroyedText, bombersDestroyedText, defendersDestroyedText, totalDestroyedText;

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
                while(enemyFightersAlive < maxFighters * 2)
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

                while (enemyBombersAlive < maxBombers * 2)
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

                while (enemyDefendersAlive < maxDefenders * 2)
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
            if (asteroidCanSpawn == true || numOfAsteroids <= 20)
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
                numOfAsteroids++;
                                   
                StartCoroutine(AsteroidTimer());
            }

            //Win triggered if all enemy weakpoints are destroyed
            if (enemyWeakpointsDestroyed >= 3)
            {
                //Win Game
                if(cutscenePlaying == false)
                {
                    cutscenePlaying = true;
                    StartCoroutine(WinGame());
                }
            }

            //Loss triggered if all ally weakpoints are destroyed
            if (allyWeakpointsDestroyed >= 3)
            {
                //Lose Game
                if (cutscenePlaying == false)
                {
                    cutscenePlaying = true;
                    StartCoroutine(LoseGame());
                }
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

            remainingText.text = $"Remaining: {remainingAllocationSlots}";
            fighterText.text = $"{fightersAllocated}";
            bomberText.text = $"{bombersAllocated}";
            defenderText.text = $"{defendersAllocated}";
            scrapText.text = $"{scrap}";

            if (shipHealthUpgradeUnlocked == true)
            {
                GameObject.FindWithTag("HealthUpgradeOwned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                healthUpgradeText.text = "Unlocked";
            }
            if (shipWeaponsUpgradeUnlocked == true)
            {
                GameObject.FindWithTag("WeaponsUpgradeOwned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                weaponsUpgradeText.text = "Unlocked";
            }
            if (numOfIncreasedShipAllocations == 3)
            {
                GameObject.FindWithTag("Tier1Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
            }
            if (numOfIncreasedShipAllocations == 6)
            {
                GameObject.FindWithTag("Tier1Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("Tier2Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
            }
            if (numOfIncreasedShipAllocations == 9)
            {
                GameObject.FindWithTag("Tier1Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("Tier2Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("Tier3Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
            }
            if (numOfIncreasedShipAllocations == 12)
            {
                GameObject.FindWithTag("Tier1Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("Tier2Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("Tier3Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("Tier4Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
            }
            if (numOfIncreasedShipAllocations >= 15)
            {
                spacecraftUpgradeText.text = "Unlocked";
                GameObject.FindWithTag("Tier1Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("Tier2Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("Tier3Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("Tier4Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("Tier5Owned").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
            }                                
        }
        if(onWeaponsScreen == true)
        {
            laserText = GameObject.FindWithTag("LaserText").GetComponent<TMP_Text>();
            bombText = GameObject.FindWithTag("BombText").GetComponent<TMP_Text>();
            missileText = GameObject.FindWithTag("MissileText").GetComponent<TMP_Text>();

            if (laserSystemActive == true)
            {
                laserText.text = "Selected";
                bombText.text = "Equip";
                missileText.text = "Equip";
                GameObject.FindWithTag("LaserEquipped").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
            }
            if (bombSystemActive == true)
            {
                laserText.text = "Equip";
                bombText.text = "Selected";
                missileText.text = "Equip";
                GameObject.FindWithTag("BombEquipped").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
            }
            if (missileSystemActive == true)
            {
                laserText.text = "Equip";
                bombText.text = "Equip";
                missileText.text = "Selected";
                GameObject.FindWithTag("MissileEquipped").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
            }
        }
        if (onLaunchScreen == true)
        {
            shipsAllocatedText = GameObject.FindWithTag("AllocatedShipsText").GetComponent<TMP_Text>();
            selectedWeaponText = GameObject.FindWithTag("SelectedWeaponText").GetComponent<TMP_Text>();
            confirmationText = GameObject.FindWithTag("ConfirmationText").GetComponent<TMP_Text>();

            shipsAllocatedText.text = $"Ships Allocated: {currentlyAllocated}";
            if (laserSystemActive == true)
            {
                selectedWeaponText.text = $"Weapon Selected: Laser";
            }
            else if (bombSystemActive == true)
            {
                selectedWeaponText.text = $"Weapon Selected: Bomb";
            }
            else if (missileSystemActive == true)
            {
                selectedWeaponText.text = $"Weapon Selected: Missile";
            }

            if(remainingAllocationSlots == 0)
            {
                confirmationText.text = "Ships Are Allocated";
                confirmationText.color = new Color32(36, 144, 48, 255);
                GameObject.FindWithTag("ConfirmationColor").gameObject.GetComponent<Image>().color = new Color32(36, 144, 48, 255);
            }
            else
            {
                confirmationText.text = "Allocations Required";
                confirmationText.color = new Color32(255, 90, 90, 255);
                GameObject.FindWithTag("ConfirmationColor").gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            }
        }
        /*if (onWinScene)
        {
            scrapText = GameObject.FindWithTag("ScrapCount").GetComponent<TMP_Text>();
            fightersDestroyedText = GameObject.FindWithTag("FightersDestroyedText").GetComponent<TMP_Text>();
            bombersDestroyedText = GameObject.FindWithTag("BombersDestroyedText").GetComponent<TMP_Text>();
            defendersDestroyedText = GameObject.FindWithTag("DefendersDestroyedText").GetComponent<TMP_Text>();
            totalDestroyedText = GameObject.FindWithTag("TotalDestroyedText").GetComponent<TMP_Text>();

            scrapText.text = $"Scrap Gained: {scrapGained + 25}";
            scrap += 25;

            fightersDestroyedText.text = $"Fighters: {fightersDestroyed}";
            bombersDestroyedText.text = $"Bombers: {bombersDestroyed}";
            defendersDestroyedText.text = $"Defenders: {defendersDestroyed}";

            totalDestroyed = fightersDestroyed + bombersDestroyed + defendersDestroyed + 1;
            totalDestroyedText.text = $"Total: {totalDestroyed}";
        }*/
        if (inGame == true)
        {
            Vector2 hotSpot = new Vector2(cursorTexture.width / 2f, cursorTexture.height / 2f);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Cursor.lockState = CursorLockMode.Confined;
            scrapText = GameObject.FindWithTag("ScrapCount").GetComponent<TMP_Text>();
            scrapText.text = $"{scrap}";
            //Cursor.visible = false;

        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            Cursor.lockState = CursorLockMode.None;           
            //Cursor.visible = true;
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
        yield return new WaitForSeconds(15f);
        asteroidCanSpawn = true;
    }

    public BlackScreen fadeController;

    public IEnumerator WinGame()
    {
        yield return new WaitForSeconds(5f);
        fadeController.FadeIn();

        AudioManagerScript.instance.Play("WinMusic");
        yield return new WaitForSeconds(2f); // Wait for seconds
        fadeController.FadeOut();

        // load the win cutscene
        SceneManager.LoadScene(20);
        Cursor.visible = false;
        AudioManagerScript.instance.Stop("GameMusic");
        AudioManagerScript.instance.Stop("Engine");
        inGame = false;

        // Load the score
        yield return new WaitForSeconds(5f);
        fadeController.FadeIn();
        yield return new WaitForSeconds(2f);
        fadeController.FadeOut();
        SceneManager.LoadScene(3);
        Cursor.visible = true;
    }

    public IEnumerator LoseGame()
    {
        yield return new WaitForSeconds(5f);
        fadeController.FadeIn();

        AudioManagerScript.instance.Play("LoseMusic");
        yield return new WaitForSeconds(2f);  // Wait for seconds
        fadeController.FadeOut();

        // load the lose cutscene
        SceneManager.LoadScene(21);
        Cursor.visible = false;
        AudioManagerScript.instance.Stop("GameMusic");
        AudioManagerScript.instance.Stop("Engine");
        inGame = false;

        // Load the score
        yield return new WaitForSeconds(5f);
        fadeController.FadeIn();
        yield return new WaitForSeconds(2f);
        fadeController.FadeOut();
        SceneManager.LoadScene(4);
        Cursor.visible = true;
    }
}
