using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{
    void Start()
    {
        string leveToLoad = LevelLoader.nextlevel;

        StartCoroutine(this.MakeTheLoad(leveToLoad)); 
    }

    IEnumerator MakeTheLoad(string level)
    {
        yield return new WaitForSeconds(8f);
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (operation.isDone == false)
        {
            yield return null;
        }
    }






}
