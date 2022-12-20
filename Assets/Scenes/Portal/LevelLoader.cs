using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader 
{
   public static string nextlevel;

   public static void LoadLevel(string name)
   {
       nextlevel = name;

       SceneManager.LoadScene("PantalladeCarga");
   }
}
