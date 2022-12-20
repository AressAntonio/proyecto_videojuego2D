using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoDroping : MonoBehaviour
{
    public GameObject[] items; //variable de tipo listado
    int activeItems; //carga el numero del objeto del listado


    // Start is called before the first frame update
    void Start()
    {
       activeItems = Random.Range(0, items.Length);//escoge el total de objetos dentro de un listado 
    }

    public void ItemsDropped()
    {
        Instantiate(items[activeItems], transform.position, Quaternion.identity); //crea el objeto dentro de la scena
    }
}
