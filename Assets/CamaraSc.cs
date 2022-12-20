using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSc : MonoBehaviour
{
    public GameObject Target;
    private Vector3 TargetPos;
    
    public float HaciaAdelnte;

    public float Smoothing;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z); 

       if(Target.transform.localScale.x == 1) //camara hacia la derecha
       {
           TargetPos = new Vector3(TargetPos.x + HaciaAdelnte, TargetPos.y, transform.position.z);
       }


       if(Target.transform.localScale.x == -1) //camara hacia la izquierda
       {
           TargetPos = new Vector3(TargetPos.x - HaciaAdelnte, TargetPos.y, transform.position.z);
       }

       transform.position = Vector3.Lerp(transform.position, TargetPos, Smoothing * Time.deltaTime);
    }
}
