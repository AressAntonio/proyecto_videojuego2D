using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PueRta : MonoBehaviour
{
    public GameObject nokey;
    public GameObject key;
    public GameObject btnPuerta;
    public Animator animatorPuerta;
    

    void Start()
    {
       key.SetActive(false);
       nokey.SetActive(false);
       btnPuerta.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.tag.Equals("key"))
      {
          AbrirPuerta.llave = 1;
          Destroy(col.gameObject);
      }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
      if(col.tag.Equals("puerta") && AbrirPuerta.llave == 0)
      {
        nokey.SetActive(true);
      }
      
      if(col.tag.Equals("puerta") && AbrirPuerta.llave == 1)
      {
        key.SetActive(true);

        btnPuerta.SetActive(true);
      }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag.Equals("puerta") && AbrirPuerta.llave == 0)
      {
        nokey.SetActive(false);
      }

      if(col.tag.Equals("puerta") && AbrirPuerta.llave == 1)
      {
        key.SetActive(false);

        btnPuerta.SetActive(false);
      }


    }


    public void botonabrirP()
    {
        animatorPuerta.SetTrigger("openDoor");
    }
}
