using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCrystal : MonoBehaviour
{
    public float cashToGive;
    public float experienceToGive;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("player"))
        {
            BanckAcconunt.instance.Money(cashToGive);
            ExperiencieScrip.instance.expModifier(GetComponent<BlueCrystal>().experienceToGive);
            Destroy(gameObject);
        }
    }

    
   
}
