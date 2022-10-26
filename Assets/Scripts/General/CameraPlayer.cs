using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
   public GameObject Player;
   public Vector2 min;
   public Vector2 max;
   Vector2 velocity;
   public float softened;

  private void FixedUpdate() 
  {
    float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x,ref velocity.x, softened);
    float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y,ref velocity.y, softened);

    transform.position = new Vector3(Mathf.Clamp(posX,min.x,min.x),Mathf.Clamp(posY,min.y,min.y),transform.position.z);
  }

}
