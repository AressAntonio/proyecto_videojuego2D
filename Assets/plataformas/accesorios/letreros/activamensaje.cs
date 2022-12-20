using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activamensaje : MonoBehaviour
{
    [SerializeField] private GameObject mensaje;

    private void Start()
    {
        mensaje.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            mensaje.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            mensaje.SetActive(false);
        }
    }
}
