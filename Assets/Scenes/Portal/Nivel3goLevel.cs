using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel3goLevel : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D col)
   {
       
       {
           LevelLoader.LoadLevel("nivel 3");
       }
   }
}
