using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNLevel : MonoBehaviour
{
    public void Scenes(string Level)
    {
       SceneManager.LoadScene(Level);
    }
}
