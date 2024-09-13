using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scrap : MonoBehaviour
{
    Rigidbody rb;

    public TMP_Text scrapText;

    private void Awake()
    {
        //Assigns projectile rigidbody
        rb = GetComponent<Rigidbody>();

        //Hide text at start
        scrapText.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerLaser" || collision.gameObject.tag == "PlayerBomb" || collision.gameObject.tag == "PlayerMissile")
        {
            GameManager.GM.scrap += 1;
            Destroy(gameObject);

            // Show text and start coroutine to hide it after 5 seconds
            StartCoroutine(DisplayScrapText());
        }
    }

        private IEnumerator DisplayScrapText()
        {
            scrapText.text = "Scrap +1";
            scrapText.gameObject.SetActive(true);

            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);

            // Hide the text
            scrapText.gameObject.SetActive(false);
        }
    }