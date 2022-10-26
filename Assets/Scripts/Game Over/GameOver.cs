using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public GameObject Canvas;

   public void Reset() 
   {
     Canvas.SetActive(false);
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void Levels(string Scene) 
   {
      SceneManager.LoadScene(Scene);
   }


}
