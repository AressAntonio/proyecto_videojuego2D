using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Controladorpersonaje2D : MonoBehaviour
{
    [SerializeField] private float fuerzaSalto = 400f; //cantidad de furza que el personaje utilizara para el salto
    [SerializeField] private bool controlAire = false; // permite decidir si se modifica o no el salto en el aire
    [SerializeField] private LayerMask queEsPiso; //determina que es el piso para el jugador
    [SerializeField] private Transform chequeoPiso; // reconoce cuando se este en el piso
    const float radioChequeo = .2f; // radio del circulo que se crea para saber si se esta en el piso
    [Range(0,1f)] [SerializeField] private float suavizarMov = 0.05f; //aqui se define la suavidad del movimiento del personaje
    private Rigidbody2D rigidbody2D; //guarda rigidbody del personage
    private bool miraDerecha = true; //determina el lugar hacia donde mirara el personaje
    private Vector3 velocidad = Vector3.zero;
    private bool enElPiso;

    

   public UnityEvent CuandoAterrizoEvent;

   
    
    

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); //busca el rigidbody2D del personaje 
       
      if(CuandoAterrizoEvent == null)
         CuandoAterrizoEvent = new UnityEvent();
        
    }

    private void FixedUpdate()
    {
        bool estabaEnElPiso = enElPiso;
        enElPiso = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(chequeoPiso.position, radioChequeo, queEsPiso);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                enElPiso = true;
                if(!estabaEnElPiso)
                   CuandoAterrizoEvent.Invoke();
            }
        }
    }

    public void Mover(float mover, bool salto)
    {
        //mueve al personaje con la velocidad objetivo
        Vector3 velObjetivo = new Vector2(mover * 10f, rigidbody2D.velocity.y);

        //se suavisa y agrega al personaje
        //SmoothDamp: cambia gradualmente el vector hacia la meya deseada mientras pasa el tiempo
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, velObjetivo, ref velocidad, suavizarMov);

        //si el personaje se mueve a la derecha y esta mirando hacia la izquierda
        if (mover > 0 && !miraDerecha)
        {
            //lo volteamos
            Flip();
        }
        else if (mover < 0 && miraDerecha)
        //se hace el proceso inverso
        {
             Flip();
        }
        
        if (enElPiso && salto)
        {
          enElPiso = false;
          rigidbody2D.AddForce(new Vector2(0f, fuerzaSalto));  
        }
   
    }
    private void Flip() //controla la horientaxion del personaje en el escenario dependiendo si mira a la izquierda o derecha
    {
        //cambia lo que esta guardado en el bool
        miraDerecha = !miraDerecha;

        //Multiplica la escala en x por -1
        Vector3 laEscala = transform.localScale;
        laEscala.x *= -1; // *= --> laEscala.x = laEscala.x * -1;
        transform.localScale = laEscala;
    }

    



}