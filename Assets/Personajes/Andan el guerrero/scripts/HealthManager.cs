using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // sirve para usar canvas con imagenes.
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{  //creacion de clases a utilizar en codigo
    Rigidbody2D pRB;
    public float BumpX, BumpY;
    public Image Corazon;
    public int CantDeCorazon;
    public RectTransform PosicionPrimerCorazon;
    public Canvas MyCanvas;
    public int offSet;
    public GameObject deathExplocion;

    // Start is called before the first frame update
    void Start()
    {
       
        
    
        pRB=GetComponent<Rigidbody2D>(); // Rigidbody de Adan el guerrero

        Transform PosCorazon = PosicionPrimerCorazon; //localizacion de imagen de corazon

        for (int i = 0; i < CantDeCorazon; i++) //aumenta numero de corazones.
        {
            Image NewCorazon = Instantiate(Corazon, PosCorazon.position, Quaternion.identity);
            NewCorazon.transform.parent = MyCanvas.transform; //permite que las imagenes aparescan dentro del cambas.
            PosCorazon.position = new Vector2(PosCorazon.position.x + offSet, PosCorazon.position.y);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy") // si el enemigo ataca a adan el guerrero
        {
            
            if(other.GetComponent<SpriteRenderer>().flipX == false) // define lugar hacia donde adan el guerrero revota despues de ser atacado
            {
            pRB.velocity = new Vector2(-BumpX, BumpY);
            }

            else if(other.GetComponent<SpriteRenderer>().flipX == true)
            {
                pRB.velocity = new Vector2(BumpX, BumpY);
            }
        

            Destroy(MyCanvas.transform.GetChild(CantDeCorazon + 1).gameObject);//destruye al ultimo corazon del cambas
            CantDeCorazon -= 1;

            if(CantDeCorazon <= 0) // sistena de muerte Adan el Guerrero
            {
                Instantiate(deathExplocion, transform.position, transform.rotation);
                
                
               
                Destroy(gameObject);
                
                Destroy(Corazon);

                SceneManager.LoadScene("nivel 1");

            }
            GetComponent<SpriteRenderer>().color = Color.red; //Mecanica de cambio de color al resivir daño adan el guerrero
            

            
        }

    }

     private void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
          GetComponent<SpriteRenderer>().color = Color.white;
        }
    } 
    
    
    private void OnTriggerExit2D(Collider2D col) 
    {
        if(col.tag == "Enemy")
        {
          GetComponent<SpriteRenderer>().color = Color.white;
        }
    } 
}