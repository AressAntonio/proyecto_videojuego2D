using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;

    private Animator anim;

    void Start()
    {
       gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>(); // llama al tag GM del objeto GameMaster
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("player"))
        {
            gm.lastCheck = transform.position; //regreasa la posicion del jugador

            anim.SetTrigger("AbrirCofre");
        }
    }

    
}
