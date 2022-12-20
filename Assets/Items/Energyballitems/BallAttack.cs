using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttack : MonoBehaviour
{
    public GameObject  player;
    private Transform playerTrans;
    private Rigidbody2D bulletRB;
    public AudioSource boomSound;

    public float bulletLife; //tiempo que el prefab bulled dura en escena antes de desaparecer
    public static int damage; //daño que ocaciona el prefab bullet a el enemigo
    public int damageRef; 

     void Awake()
    {
        damage = damageRef;
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player"); //da direccion a prefab bullet bullet dependiendo la posicion del jugador
        playerTrans = player.transform;
        
    }

    void Update()
    {
        Destroy(gameObject, bulletLife);//destrulle el prefab bullet
    }
   
   void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Plataforma" || col.tag == "enemigo") //se cumplen las funciones mencionadas si el tag es Plataforma o Enemy
        {
            GetComponent<ParticleSystem>().Play(); //aplica el sistema de particulas del bullet al colicionar con el tag
            boomSound.Play(); //agrega el somido de explocion a el bullet al destruirce
            GetComponent<SpriteRenderer>().enabled = false; //oculta al bullet de la escena al colicionar con el Tag
            GetComponent<CircleCollider2D>().enabled = false; //desactiva la colicion al ocultar el bullet

        

        }
    } 
}
