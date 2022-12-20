using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemiga : MonoBehaviour
{
    
    public Animator anim;
    
    [SerializeField]
    Transform player; //posicion del personaje

    [SerializeField]
    float rangoAgro; //distancia a la que el enemigo ve al player y agresividad.
    public float velocidadMov; 
    private bool miraDerecha;
    Rigidbody2D rb2d;
    


    void Start()
    {
        miraDerecha = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    

    // generar instancias del player
    void Update()
    {
      //distancia hasta el player
      float distJugador = Vector2.Distance(transform.position, player.position);
      Debug.Log("Distancia del jugador;" + distJugador);

      if(distJugador < rangoAgro && Mathf.Abs(distJugador) > 1) //funcion para seguir al player
      {
          PerseguirJugador(); 
          anim.SetFloat("velocidad", 1);
          anim.SetBool("ataque", false);
      }
      else if(Mathf.Abs(distJugador) < 1) //ataca al jugador si se esta -1 de distancia
      {
        anim.SetBool("ataque", true);
      }  
      else
      {
          NoPerseguir();
          anim.SetFloat("velocidad", 0); //no se persigue al jugador y enemigo se queda en su pocicion original
      }
    } 
    
    private void NoPerseguir()
    {
        rb2d.velocity = Vector2.zero;
    }

    private void PerseguirJugador()
    {
        //si el enemigo esta a la izquierda del jugador entonces gira y se mueve a la derecha
        if (transform.position.x < player.position.x && !miraDerecha)
        {
            rb2d.velocity = new Vector2(velocidadMov, 0f);
            Flip();
        }
        else if (transform.position.x > player.position.x && miraDerecha)
        {
            rb2d.velocity = new Vector2(-velocidadMov, 0f);
            Flip();
        }
        else if(!miraDerecha)
        {
            rb2d.velocity = new Vector2(-velocidadMov, 0f);
        }
        else if(miraDerecha)
        {
            rb2d.velocity = new Vector2(velocidadMov, 0f);
        }

    }
    private void Flip()
    {
        //define nuevamente hacia donde mira el jugador
        miraDerecha = !miraDerecha;

        //multiplica la escala en x del personaje por -1
        Vector3 laEscala = transform.localScale;
        laEscala.x *= -1;
        transform.localScale = laEscala;
    }
}
