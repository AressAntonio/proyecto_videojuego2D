using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerninja : MonoBehaviour
{
    public int enemyHealth; //determina la salud del enemigo
    public int enemyValue; //los puntos que se otorga al destruir a el enemigo

    private Animator animator; // llama a las animaciones de ninja

    public float animatorDelay; // tiempo duracion de animacion

    public static bool enemyDead = false; // detiene los movimientos del ninja al morir

    private float curHealth;

    public GameObject healthBar;

    DroppingItems items; //referencia de codigo dejar objeto

    public bool isInmune;

    public float InmunityTime;
    Blink material;

    SpriteRenderer sprite;
    public float knockbackForceX;
    public float knockbackForceY;

    Rigidbody2D rb;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      sprite = GetComponent<SpriteRenderer>();
      material = GetComponent<Blink>();
      curHealth = enemyHealth;
      animator = GetComponent<Animator>(); //llama a la animacion de ninja
      items = GetComponent<DroppingItems>(); // busca el componente dentro del enemigo
    }

    void OnTriggerEnter2D(Collider2D col) //accion al atravesar un collider en formato 2d
    {
        if(col.CompareTag("Bullet"))//da la orden de destruir al enemigo cuando su vida sea igual o menor a cero.
        {
            curHealth -= BulletMovement.damage; // llama al script bulletmovement y a su seccion damage del mismo
            float bariength = curHealth / enemyHealth;
            SetHealthBar(bariength); // determina el tamaño de la barra cada que ninja sea atacado
            
            if(curHealth <= 0)
            {
              enemyDead = true;
              animator.SetBool("ninjamuere", true); // reproduce la animacion de muerte de ninja
             
              Debug.Log(enemyValue);

              Destroy(gameObject, animatorDelay); // detruye a BadEye despues del tiempo concluido de la animacion de muerte

              items.ItemsDropped();
            }
            
        }
        
        if(col.CompareTag("attack"))
        {
          curHealth -= 15;
          float bariength = curHealth / enemyHealth;
          SetHealthBar(bariength); // determina el tamaño de la barra cada que npc sea atacado

          if(col.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }


          if(curHealth <= 0)
            {
              enemyDead = true;
              animator.SetBool("ninjamuere", true); // reproduce la animacion de muerte de ninja
             
              Debug.Log(enemyValue);

              Destroy(gameObject, animatorDelay); // detruye a BadEye despues del tiempo concluido de la animacion de muerte

              items.ItemsDropped();
            }
        }

        if(col.CompareTag("ballAttack"))
        {
          curHealth -= 25;
         
          float bariength = curHealth / enemyHealth;
          SetHealthBar(bariength);
           
          if(curHealth <= 0)
          {
            enemyDead = true;
            animator.SetBool("ninjamuere", true); // reproduce la animacion de muerte de BadEye
            Debug.Log(enemyValue);
            Destroy(gameObject, animatorDelay); // detruye a BadEye despues del tiempo concluido de la animacion de muerte
            items.ItemsDropped();
          }
        
        }

       
        

    }
    
    public void SetHealthBar(float eHealth) //determina el daño de salud cada que el prefab bullet impacte a ninja
    {
      healthBar.transform.localScale = new Vector3(eHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z); 
    }

   
}
