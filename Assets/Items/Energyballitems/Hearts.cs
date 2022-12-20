using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hearts : MonoBehaviour
{
    public Text heartsText;

    public int heartsAmount;

    public static Hearts instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        heartsText.text = "x " + heartsAmount.ToString();
    }

    public void SubItem(int subItemAmount)
    {
        heartsAmount += subItemAmount;
        
        heartsText.text = "x " + heartsAmount.ToString();
    }
    
}
