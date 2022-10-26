using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
   public Transform PointCannon;
   public GameObject Bullet;
   

   private void Start() 
   {
       InvokeRepeating("Shoot", 0.8f,0.8f);
   }

   void Shoot() 
   {
      Instantiate(Bullet,PointCannon.transform.position,PointCannon.transform.rotation);  
   }


}
