using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int ballToGive;

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>(); //llama a la animacion de BadEye
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("player"))
        {
            Hearts.instance.SubItem(ballToGive);

            Destroy(gameObject);

            animator.SetBool("explocion", true);

            
        }
    }
}
