using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptMenu : MonoBehaviour
{
    public static bool gameP;
    public static bool boolseguroP;
    public GameObject menuP;
    public GameObject seguroP;

     void Start()
    {
      menuP.SetActive(false);
      seguroP.SetActive(false);
    }


    public void SwitchPause()
    {
        if(gameP)
        {
            bntContinuar();
        }
        else
        {
            bntPause();
        }
    }

    void bntContinuar()
    {
        menuP.SetActive(false);
        Time.timeScale = 1;
        gameP = false;

    }

    void bntPause()
    {
        menuP.SetActive(true);
        Time.timeScale = 0;
        gameP = true;
    }

    public void mPrincipal()
    {
      SceneManager.LoadScene("MenuInicio");
    }

    public void panel2()
    {
        seguroP.SetActive(true);
    }

    public void salirPno()
    {
        seguroP.SetActive(false);
    }

    public void salirPsi()
    {
        Debug.Log("salistedeljuego");
        Application.Quit();
    }

    
}
