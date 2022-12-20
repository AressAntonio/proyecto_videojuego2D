using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{

    public int HeartCost;

    public GameObject energyball;

    

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseSubWeapons();
    }

    public void UseSubWeapons()
    {
        if(Input.GetButtonDown("Fire5")&& HeartCost <= Hearts.instance.heartsAmount)
        {
         
            
            Hearts.instance.SubItem(-HeartCost);
            GameObject subItem = Instantiate(energyball, transform.position, Quaternion.Euler(0,0,-132));
            
            

            if(transform.localScale.x < 0)
            {
              subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f), ForceMode2D.Force);
              subItem.transform.localScale = new Vector2(-1, -1);
            }
            else
            {
              subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f), ForceMode2D.Force);
            }

             

            

            
        }
        
    }


   
}
