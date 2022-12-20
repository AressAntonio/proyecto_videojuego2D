using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GotonexLevel : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col)
   {
       
       {
           LevelLoader.LoadLevel("nivel 2");
       }
   }
}
