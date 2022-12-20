using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    public GameObject  player;
    private Transform playerTrans;
    private Rigidbody2D bulletRB;

    public float bulletSpeed; //velocidad de movimiento del prefab bullet

    public float bulletLife; //tiempo que el prefab bulled dura en escena antes de desaparecer

    public AudioSource boomSound; //sonido del prefab bullet

    public static int damage; //daño que ocaciona el prefab bullet a el enemigo
    public int damageRef; //controlador de daño prefab bullet en unity

    void Awake()
    {
        damage = damageRef;
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player"); //da direccion a prefab bullet bullet dependiendo la posicion del jugador
        playerTrans = player.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(playerTrans.localScale.x > 0) // si el valor del jugador en posicion es positivo prefab bullet sale disparada hacia la derecha.
        {
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y); 
            transform.localScale = new Vector3(2, 2, 2); //hace que el prefab bullet  se oriente hacia la derecha

        }
        else
        {
          bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y); // prefab bullet sale disparada hacia la izquierda
          transform.localScale = new Vector3(-2, 2, 2); // hace que el prefab bullet se oriente hacia la izquierda
        }
        
      
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletLife);//destrulle el prefab bullet
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Plataforma" || col.tag == "Enemy") //se cumplen las funciones mencionadas si el tag es Plataforma o Enemy
        {
            GetComponent<ParticleSystem>().Play(); //aplica el sistema de particulas del bullet al colicionar con el tag
            boomSound.Play(); //agrega el somido de explocion a el bullet al destruirce
            GetComponent<SpriteRenderer>().enabled = false; //oculta al bullet de la escena al colicionar con el Tag
            GetComponent<CircleCollider2D>().enabled = false; //desactiva la colicion al ocultar el bullet

        }
    } 
}
