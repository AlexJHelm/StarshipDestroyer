using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MissionReport : MonoBehaviour
{
    public TMP_Text  scrapText, fightersDestroyedText, bombersDestroyedText, defendersDestroyedText, totalDestroyedText;


    // Update is called once per frame
    void Update()
    {
        scrapText = GameObject.FindWithTag("ScrapCount").GetComponent<TMP_Text>();
        fightersDestroyedText = GameObject.FindWithTag("FightersDestroyedText").GetComponent<TMP_Text>();
        bombersDestroyedText = GameObject.FindWithTag("BombersDestroyedText").GetComponent<TMP_Text>();
        defendersDestroyedText = GameObject.FindWithTag("DefendersDestroyedText").GetComponent<TMP_Text>();
        totalDestroyedText = GameObject.FindWithTag("TotalDestroyedText").GetComponent<TMP_Text>();

        scrapText.text = $"Scrap Gained: {GameManager.GM.scrapGained}";    

        fightersDestroyedText.text = $"Fighters: {GameManager.GM.fightersDestroyed}";
        bombersDestroyedText.text = $"Bombers: {GameManager.GM.bombersDestroyed}";
        defendersDestroyedText.text = $"Defenders: {GameManager.GM.defendersDestroyed}";

        GameManager.GM.totalDestroyed = GameManager.GM.fightersDestroyed + GameManager.GM.bombersDestroyed + GameManager.GM.defendersDestroyed + 1;
        totalDestroyedText.text = $"Total: {GameManager.GM.totalDestroyed}";

    }
}
