using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComenJuego : MonoBehaviour
{
     public void StartGame()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
