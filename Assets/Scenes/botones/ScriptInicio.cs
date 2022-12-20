using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptInicio : MonoBehaviour
{
    public void StartGame()
    {
    
        SceneManager.LoadScene("nivel 1");
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
        print("game closed");
    }

    public void GoToMainmenu()
    {
       SceneManager.LoadScene("MenuInicio");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Creditos");
    }
}
