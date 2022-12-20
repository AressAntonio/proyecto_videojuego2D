using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorazonVida : MonoBehaviour
{
    public float healthToGive;
   
   private void OnTriggerEnter2D(Collider2D col)
   {
       if(col.CompareTag("player"))
       {
           col.GetComponent<PlayerHealth>().health += healthToGive;
           
           Destroy(gameObject);
       }
   }
}
