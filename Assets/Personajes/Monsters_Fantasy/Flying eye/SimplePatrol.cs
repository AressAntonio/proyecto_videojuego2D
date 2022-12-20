using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatrol : MonoBehaviour
{ // Movimiento de enemigo De punto a punto.
    
    public GameObject startPoint;
    public GameObject endPonint;
    
    public float enemySpeed;
    private bool isGoingRight;

    
    
    
    
    
    void Start()
    {
       if (!isGoingRight) // se determina ruta de movimiento punto a punto de BadEye
       {
           transform.position = startPoint.transform.position;
       }
       
       else
       {
           transform.position = endPonint.transform.position;
       }

    }

    
    void Update() //define movimientos de BadEye.
    {
        if(EnemyManager.enemyDead == false) //detiene los movimientos al morir
        {
            if (!isGoingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPonint.transform.position, enemySpeed * Time.deltaTime); //velocidad de movimiento
            
            if(transform.position == endPonint.transform.position) //mueve a BadEye al endPoint
            {
            isGoingRight = true;
            GetComponent<SpriteRenderer>().flipX = true; //gira a BadEye mirando hacia la derecha
            }
        }   

        if (isGoingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, enemySpeed * Time.deltaTime);
            
            if(transform.position == startPoint.transform.position) //mueve a BadEye al startPoint
            {
            isGoingRight = false;
            GetComponent<SpriteRenderer>().flipX = false; //gira a BadEye mirando hacia la izquierda
            }
        }
        }
    }
    
    
        
    

    public void OnDrawGizmos() //permite hacer algunos elementos dentro del editor con opcion visual de lo que se esta realizando
    {
        Gizmos.DrawLine(startPoint.transform.position, endPonint.transform.position); //crea uana linea para manipular la trayectoria de movimiento en unity
    }
}
