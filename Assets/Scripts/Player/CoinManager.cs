using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text totalCoins;
    public Text coinsCollected;

    private int TotalCoinLevel;

    public int NextScene;

    private int CantidadNiveles = 8;


    //Win
    public GameObject Win;
    public GameObject UI;

    public GameObject GameOver;
    public GameObject Player;
   

    private void Start() 
    {
        TotalCoinLevel = transform.childCount;
        NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        //Para borrar los datos:
        //PlayerPrefs.DeleteAll();
    }

    private void Update() 
    {
        totalCoins.text = TotalCoinLevel.ToString();
        coinsCollected.text = transform.childCount.ToString();
        Coins();
    }


    void Coins ()
    {   
  
        if(SceneManager.GetActiveScene().buildIndex == CantidadNiveles && transform.childCount == 0)
        {
          SceneManager.LoadScene(2);
        } 

        else if(transform.childCount == 0)
        {
           Player.GetComponent<BoxCollider2D>().enabled = false;
           Win.SetActive(true); 
           Destroy(Player); 
           Destroy(GameOver);
           UI.SetActive(false);

        if(NextScene > PlayerPrefs.GetInt("Level"))
        {
           PlayerPrefs.SetInt("Level", NextScene);
        }
        } 
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(NextScene);
        
        if(NextScene > PlayerPrefs.GetInt("Level"))
        {
           PlayerPrefs.SetInt("Level", NextScene);
        }       
        
    }

    public void Levels(string Scene) 
    {
      SceneManager.LoadScene(Scene);
    }
    
}
