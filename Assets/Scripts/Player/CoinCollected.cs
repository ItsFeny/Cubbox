using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollected : MonoBehaviour
{
    public AudioSource CoinEfect;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
         if(collision.CompareTag("Player"))
        { 
           CoinEfect.Play();
           //GetComponent<SpriteRenderer>().enabled = false;
           //gameObject.transform.GetChild(0).gameObject.SetActive(true);
           Destroy(gameObject);
        }
    }
    
}
