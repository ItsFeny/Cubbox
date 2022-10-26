using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : MonoBehaviour
{
    public GameObject Player;
    public GameObject Dead;
       
    private void Start() 
    {
      //Dead = GameObject.FindGameObjectWithTag("Mine");
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.CompareTag("Player"))
       {
          Destroy(Player,0.5f);
          Dead.SetActive(true);
       }
    }
}
