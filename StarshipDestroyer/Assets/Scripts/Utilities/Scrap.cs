using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        //Assigns projectile rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerLaser" || collision.gameObject.tag == "PlayerBomb" || collision.gameObject.tag == "PlayerMissile")
        {
            GameManager.GM.scrap += 1;

            ScrapTxt scrapTxt = FindObjectOfType<ScrapTxt>();
            if (scrapTxt != null)
            {
                scrapTxt.ShowScrapCanvas();
            }

            Destroy(gameObject);

        }
    }
}
