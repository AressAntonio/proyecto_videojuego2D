using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
   private static GameMaster instace;

   public Vector2 lastCheck;


   private void Awake()
   {
       if(instace == null)
       {
           instace = this;
           DontDestroyOnLoad(instace); //no destrulle al objeto mientras cumpla una funcion
       }
       else
       {
           Destroy(gameObject); //destruye al objeto si no cumple la funcion
       }
   }
}
