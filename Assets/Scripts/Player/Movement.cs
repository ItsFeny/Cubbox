using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Movement : MonoBehaviour
{
    float moveSpeed = 4f;

    [SerializeField]
    float areaCicle;

    [SerializeField]
    Vector2 pointMove;

    [SerializeField]
    Vector2 offsetPointMove;

    [SerializeField]
    LayerMask obstacule;

    Vector2 input;

    bool movement = false;
  
    Animator animator;

    public AudioSource MoveEfect;


    void Start ()
    {
        pointMove = transform.position;
        animator = GetComponent<Animator>();
    }


     void FixedUpdate()
    {

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        


        if (movement)
        {
           transform.position = Vector2.MoveTowards(transform.position, pointMove, moveSpeed * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, pointMove) == 0)
        {
            movement = false;
        }

        
        //Derecha
        if((input.x != 0) && input.x > 0 && !movement)
        {
            Vector2 point = new Vector2 (transform.position.x,transform.position.y) + offsetPointMove + input;
            
            //Animacion y Flip del sprite
            animator.SetBool("isMoveRightLeft",true);
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);;


            //Sonido de movimiento
            MoveEfect.Play();
    

            if(!Physics2D.OverlapCircle(point, areaCicle, obstacule))
            {
                movement = true;
                pointMove += input;
            }   

        }

        else 
        {
             animator.SetBool("isMoveRightLeft",false);
        }


       

        //izquierda
        if((input.x != 0) && input.x < 0 && !movement)
        {
            Vector2 point = new Vector2 (transform.position.x,transform.position.y) + offsetPointMove + input;

            //Animacion y Flip del Sprite
            transform.localRotation = Quaternion.Euler(0.0f, -177.0f, 0.0f);;
            animator.SetBool("isMoveRightLeft",true);

            //Sonido de movimiento
            MoveEfect.Play();

            if(!Physics2D.OverlapCircle(point, areaCicle, obstacule))
            {
                movement = true;
                pointMove += input;
            }         

        }



      
  

        //Arriba
        if((input.y != 0) && input.y > 0 && !movement)
        {
            Vector2 point = new Vector2 (transform.position.x,transform.position.y) + offsetPointMove + input;
    
            //Animacion y Flip del Sprite
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);;
            animator.SetBool("isMoveUpDown", true);

            //Sonido de movimiento
            MoveEfect.Play();
    

            if(!Physics2D.OverlapCircle(point, areaCicle, obstacule))
            {
                movement = true;
                pointMove += input;  
            }
            
        }
        else 
            {
                animator.SetBool("isMoveUpDown", false);
            }


        //Abajo
        if((input.y != 0) && input.y < 0 && !movement)
        {
            Vector2 point = new Vector2 (transform.position.x,transform.position.y) + offsetPointMove + input;
           
            //Animacion y Flip del Sprite
            //transform.localRotation = Quaternion.Euler(-180.983f, 0.0f, 0.0f);
            animator.SetBool("isMoveUpDown", true);

            //Sonido de movimiento
            MoveEfect.Play();

            if(!Physics2D.OverlapCircle(point, areaCicle, obstacule))
            {
                movement = true;
                pointMove += input;
            }
        }


    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pointMove + offsetPointMove, areaCicle);
    }

   
  
      

    //Metodos para botones tactiles
    public void Up()
    {    
        if(!movement)
         {
            //Animacion y Flip del Sprite
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            animator.SetBool("isMoveUpDown", true);

            //Sonido de movimiento
            MoveEfect.Play();

            input.y = 1;
            Vector2 point = new Vector2 (transform.position.x,transform.position.y) + offsetPointMove + input;

            if(!Physics2D.OverlapCircle(point, areaCicle, obstacule))
            {
                movement = true;
                pointMove += input;  
            }
        }
         else 
            {
                animator.SetBool("isMoveUpDown", false);
            }       
       
    }
    

      public void Down()
    {    
       
        if(!movement)
        {
            //Animacion y Flip del Sprite
            //transform.localRotation = Quaternion.Euler(-180.983f, 0.0f, 0.0f);
            animator.SetBool("isMoveUpDown", true);

            //Sonido de movimiento
            MoveEfect.Play();

            input.y = -1;
            Vector2 point = new Vector2 (transform.position.x,transform.position.y) + offsetPointMove + input;

            if(!Physics2D.OverlapCircle(point, areaCicle, obstacule))
            {
                movement = true;
                pointMove += input;
                
            }
        }      
       
    }


      public void Right()
    {    
        if(!movement)
         {
            //Animacion y Flip del sprite
            animator.SetBool("isMoveRightLeft",true);
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);


            //Sonido de movimiento
            MoveEfect.Play();

            input.x = 1;
            Vector2 point = new Vector2 (transform.position.x,transform.position.y) + offsetPointMove + input;

            if(!Physics2D.OverlapCircle(point, areaCicle, obstacule))
            {
                movement = true;
                pointMove += input;
                
            }  
        }
        else 
        {
             animator.SetBool("isMoveRightLeft",false);
        }
           
       
    }


      public void Left()
    {    
        if(!movement)
        {
            //Animacion y Flip del Sprite
            transform.localRotation = Quaternion.Euler(0.0f, -177.0f, 0.0f);;
            animator.SetBool("isMoveRightLeft",true);

            //Sonido de movimiento
            MoveEfect.Play();

            input.x = -1;
            Vector2 point = new Vector2 (transform.position.x,transform.position.y) + offsetPointMove + input;

            if(!Physics2D.OverlapCircle(point, areaCicle, obstacule))
            {
                movement = true;
                pointMove += input;
                
            }
       
        }
           
    }

}
