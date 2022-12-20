using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour //control de vida de enemigo.
{
    public int enemyHealth; //determina la salud del enemigo
    public int enemyValue; //los puntos que se otorga al destruir a el enemigo

    private Animator animator; // llama a las animaciones de BadEye

    public float animatorDelay; // tiempo duracion de animacion

    public static bool enemyDead = false; // detiene los movimientos del BadEye al morir

    private float curHealth;

    public GameObject healthBar;

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
      animator = GetComponent<Animator>(); //llama a la animacion de BadEye
    }

    void OnTriggerEnter2D(Collider2D col) //accion al atravesar un collider en formato 2d
    {
        if(col.tag == "Bullet") //da la orden de destruir al enemigo cuando su vida sea igual o menor a cero.
        {
            curHealth -= BulletMovement.damage; // llama al script bulletmovement y a su seccion damage del mismo
            float bariength = curHealth / enemyHealth;
            SetHealthBar(bariength); // determina el tamaño de la barra cada que BadEye sea atacado
            
            if(curHealth <= 0)
            {
              enemyDead = true;
              animator.SetBool("isDead", true); // reproduce la animacion de muerte de BadEye
             
              Debug.Log(enemyValue);

              Destroy(gameObject, animatorDelay); // detruye a BadEye despues del tiempo concluido de la animacion de muerte
            }
            
        }
        
        if(col.CompareTag("attack") && !isInmune)
        {
          curHealth -= 15;
            
            float bariength = curHealth / enemyHealth;
            StartCoroutine(Inmunity());
            SetHealthBar(bariength);

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
              animator.SetBool("isDead", true); // reproduce la animacion de muerte de BadEye
              
              Debug.Log(enemyValue);

              Destroy(gameObject, animatorDelay); // detruye a BadEye despues del tiempo concluido de la animacion de muerte
            }

         
        }

        if(col.CompareTag("ballAttack") && !isInmune)
         {
            curHealth -= 25; 
            StartCoroutine(Inmunity());
            float bariength = curHealth / enemyHealth;
            SetHealthBar(bariength); // determina el tamaño de la barra cada que BadEye sea atacado

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
              animator.SetBool("isDead", true); // reproduce la animacion de muerte de BadEye
             
              Debug.Log(enemyValue);

              Destroy(gameObject, animatorDelay); // detruye a BadEye despues del tiempo concluido de la animacion de muerte
            }
         }  
    }
    public void SetHealthBar(float eHealth) //determina el daño de salud cada que el prefab bullet impacte a BadEye
    {
      healthBar.transform.localScale = new Vector3(eHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z); 
    }

     IEnumerator Inmunity()
    {
      isInmune = true;
      sprite.material = material.blink;
      yield return new WaitForSeconds(InmunityTime);
      isInmune = false;
      sprite.material = material.original;
    }
}
