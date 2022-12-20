using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlAdan : MonoBehaviour
{
    public Controladorpersonaje2D controlador;
    public Animator animator; // llama al Animator de Unity
    float movimientoH = 0f;   // valor que podra controlar desde  unity
    public float vcorrer = 40f; // valor correr que se podra controlar desde unity
    bool salto = false;         // negacionn de salto cuando se hacen tranciciones de movimiento
    public AudioSource shootingSound; // llama a Audio en unity
    
    

    public Transform bulletSpawner; //llama a la posicion de objeto llamado bulletSpawner
    public GameObject bulletPrefab; //llama a el objeto bulletPrefab

     

    
    

    
    

    
    
    //toma de valor con el que el jugador presiona
    void Update()
    {
        movimientoH = Input.GetAxisRaw("Horizontal") * vcorrer;
        animator.SetFloat("velocidad", Mathf.Abs(movimientoH));
        PlayerShooting();
        

        

       
       

        if(Input.GetButtonDown("Jump")) //boton que se dara por defecto para realizar salto 
        {
            salto = true;
            animator.SetBool("EstoySaltando", true); //guarda true en un boleano llamado EstoySaltando


            
        }

       

       
    }

    public void CuandoPiso() //se de termina objeto para realizar accion Estoy saltando
    {
        animator.SetBool("EstoySaltando", false); //acciona la animacion de salto 
    }

    //FixedUpdate aplica el movimiento al personaje
    private void FixedUpdate()
    {
        //mover personaje
        controlador.Mover(movimientoH * Time.fixedDeltaTime, salto); //velocidad de movimiento
        salto = false;

        
    }  

    public void PlayerShooting() 
    {
       if(Input.GetButtonDown("Fire4")) //determina boton por defecto para accionar animacion de ataque
       {
           animator.SetBool("ataqueadan2", true);
           shootingSound.Play(); //activa el audio
           Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation); //activa el prefab llamado bullet
            
       }
       else if(Input.GetButtonUp("Fire4")) //determina en que momento se deja de realizar la animacion de ataque
       {
           animator.SetBool("ataqueadan2", false);
       }

       if(Input.GetButtonDown("Fire5"))
        {
            
            animator.SetBool("BallAttack", true);
        }
        else if(Input.GetButtonUp("Fire5"))
        {
            animator.SetBool("BallAttack", false);
        }
        
        if(Input.GetButtonDown("fire6"))
        {
            shootingSound.Play();
            animator.SetBool("ataque", true);
        }
        else if(Input.GetButtonUp("fire6"))
        {
            animator.SetBool("ataque", false);
        }
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("void"))
        {
           
            SceneManager.LoadScene("nivel 1");
        }
    } 
        
}
   
        

    
    
    
    
