using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D adan;
    
    [SerializeField]
    private float adanSpeed;
   
    // Start is called before the first frame update
    void Start()
    {
        adan = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            adan.velocity = new Vector2(adanSpeed, adan.velocity.y);
            transform.localScale = new Vector3(6, 5, 1);
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            adan.velocity = new Vector2(-adanSpeed, adan.velocity.y);
            transform.localScale = new Vector3(-6, 5, 1);
        }
    }
}
