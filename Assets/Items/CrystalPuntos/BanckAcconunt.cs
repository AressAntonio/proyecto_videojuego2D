using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BanckAcconunt : MonoBehaviour
{
    public float bank;

    public Text bankText;


    public static BanckAcconunt instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        bankText.text = "x " + bank.ToString();
    }

    public void Money(float cashCollected)
    {
        bank += cashCollected;
        bankText.text = "x " + bank.ToString();

    }
    
}
