using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    float z;
    public AudioSource SawEfect;

    private void Start() 
    {
      SawEfect.Play();
    }
    private void FixedUpdate () 
    {
       Rotation();  
       transform.position += Vector3.right * Time.deltaTime * 3f;
       Destroy(gameObject, 2f);
    }

    void Rotation ()
    {
       z += Time.deltaTime * 700;
       transform.rotation = Quaternion.Euler(0,0,-z);
    } 
    

}
