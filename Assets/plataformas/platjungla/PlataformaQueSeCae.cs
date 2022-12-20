using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaQueSeCae : MonoBehaviour
{
    public float FallDelay = 0.3f; //tiempo que tardara la palataforma a moverse para caer
    public float shakeAmount = 5f; // fuerza de vibracion de la plataforma antes de caer
    bool readyToshake = false; // determina momento en el que se puede comenzar a vibrar la plataforma antes de caer
    Rigidbody2D rb; // referencia del objeto
    Vector3 originalPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(readyToshake)
        {
            Vector3 newPos = originalPos + Random.insideUnitSphere * (Time.deltaTime * shakeAmount); //horientacion de vibracion de plataforma
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos; 
        }
    }

    private void OnCollisionEnter2D(Collision2D col) //identifica que la accion de la plataforma se ejecura al contacto con el player
    {
        if(col.gameObject.CompareTag("player"))
        {
           StartCoroutine(Falling(FallDelay));
        }
    }

    IEnumerator Falling(float delay)
    {
        originalPos = transform.position; // posision en que se encuentra la plataforma

        yield return new WaitForSeconds(delay); //tiempo de espera

        readyToshake = true; //ejecuta la vibracion de la plataforma

        yield return new WaitForSeconds(1.0f); // espera de tiemp adicional para cambiar el tipo de bodytype a RigidbodyType2D.Daynamic y la plataforma tenga movimiento y sea afectado por la gravedad y caega la plataforma

        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
