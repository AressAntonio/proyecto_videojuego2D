using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCrystal : MonoBehaviour
{
     public float cashToGive;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("player"))
        {
            BanckAcconunt.instance.Money(cashToGive);
            Destroy(gameObject);
        }
    }
}
