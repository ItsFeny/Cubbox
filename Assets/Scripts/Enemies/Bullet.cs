using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float speed;
   public AudioSource EfectCannon;

   private void Start() 
   {
     EfectCannon.Play();
   }
   private void Update()
   {
       
       transform.Translate(speed * Time.deltaTime,0,0);
       Destroy(gameObject,1f);
   }
  
}
