using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
     public GameObject deathExplocion;
    public float health;
    public float maxHealth;

    public Image healthImg;

    bool isInmune;

    public float InmunityTime;
    Blink material;

    SpriteRenderer sprite;
     public float knockbackForceX;
     public float knockbackForceY;

     Rigidbody2D rb;

     public static PlayerHealth instance;


     private void Awake()
     {
         if(instance == null)
         {
             instance = this;
         }
     }

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
    }
    

     private void Update()
    {
        healthImg.fillAmount = health / maxHealth;
        
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")&& !isInmune) // si el enemigo ataca a adan el guerrero
        {
            
            health -= 10;
        
            
            StartCoroutine(Inmunity());

            if(other.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            
            if(health <= 0) // sistena de muerte Adan el Guerrero
            {
                Instantiate(deathExplocion, transform.position, transform.rotation);
                
                Destroy(gameObject);

                SceneManager.LoadScene("nivel 1");
            }

            
        }
        
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
