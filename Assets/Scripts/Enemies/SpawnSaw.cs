using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSaw : MonoBehaviour
{
   public Transform Point;
   public GameObject Saw;

   private void Start() 
   {
       InvokeRepeating("Spawn", 0.7f,6f);
   }

   void Spawn() 
   {
      Instantiate(Saw,Point.transform.position,Point.transform.rotation);  
   }

}
