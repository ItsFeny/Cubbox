using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedScene : MonoBehaviour
{
    public Button [] LevelButtons;

    private void Start() 
    {
        int Level = PlayerPrefs.GetInt("Level", 3);

        for(int i = 0; i < LevelButtons.Length; i++)
        {
           if(i + 3 > Level)
           {
              LevelButtons[i].interactable = false;
           }
        }
    }
}
