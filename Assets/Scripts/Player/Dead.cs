using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{  

    //Efectos de sonido
    public AudioSource DeadEfect;
    public AudioSource MusicGameplay;

    Color color;


    //Refencia mina
    Animator MineAnimation;
    AudioSource Alarm;
    public GameObject MineObject;

    //Casilla que se rompera
    public GameObject BoxMine;
    public GameObject [] BoxFalse;
    public GameObject BoxBroken;
    Renderer ColorChange;

    AudioSource BoxEfect;

    
   
   //Variables del cronometro
    public Text TimeText;
    public int M,S;

    float Remaining;
    bool On;

    public GameObject Player;

    //Win referencia
    public GameObject Win;


    //Referencia canvas game over
    public GameObject GameOver;

    private void Awake() 
    {
        Remaining =  (M * 60) + S;
        On = true;
    }

    private void Start()
    {
       MineObject = GameObject.FindGameObjectWithTag("Mine");
       MineAnimation = MineObject.GetComponent<Animator>();
       Alarm = MineObject.GetComponent<AudioSource>();
       BoxMine = GameObject.FindGameObjectWithTag("BoxMine");
    }

    private void Update()
    {
        if(On)
        {
           Remaining -= Time.deltaTime;
           
           if(Remaining < 1)
           {
              On = true;

              //Muerte del player & parada del tiempo 
              MusicGameplay.mute = true;
              GetComponent<SpriteRenderer>().enabled = false;
              gameObject.transform.GetChild(1).gameObject.SetActive(true);  
              Destroy(gameObject, 0.5f);
              Destroy(Win);
              DeadEfect.Play(); 
              GameOver.SetActive(true);     
           }

           int TempMin = Mathf.FloorToInt(Remaining/60);
           int TempSeg = Mathf.FloorToInt(Remaining%60);

           TimeText.text = string.Format("{00:00}:{01:00}", TempMin, TempSeg);
        }  
    }


   //Muerte Normal
   private void OnTriggerEnter2D(Collider2D other) 
   {
      if(other.CompareTag("Enemy"))
      {
         MusicGameplay.mute = true;
         GetComponent<SpriteRenderer>().enabled = false;
         gameObject.transform.GetChild(1).gameObject.SetActive(true);  
         Destroy(Win);
         Destroy(gameObject,0.5f);
         DeadEfect.Play();
         GameOver.SetActive(true); 
      }

      if(other.CompareTag("Mine"))
        {
           MineAnimation.enabled = !MineAnimation.enabled;
           Alarm.Play();
           Destroy(Win);
           Destroy(MineObject, 1f);
           Destroy(BoxMine, 1f);
           StartCoroutine(WaitCoroutine(0.8f));
           StartCoroutine(PlayerDead(1f));
           //muerte
           
        }

   }

  IEnumerator WaitCoroutine(float time)
  {
     yield return new WaitForSeconds(time);
     BoxBroken.SetActive(true); 
  }

  IEnumerator PlayerDead(float time)
  {
     yield return new WaitForSeconds(time);
     BoxFalse[0].SetActive(true);
     BoxFalse[1].SetActive(true);
     BoxFalse[2].SetActive(true);
     BoxFalse[3].SetActive(true);
     BoxFalse[4].SetActive(true);
  }


}
