using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExperiencieScrip : MonoBehaviour
{

    public Image expeImage;
    public Text crrLvlText;
    public int currentLvl;
    public float currentExperience;
    public float expTNL;
    public static ExperiencieScrip instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLvl = 0;
        crrLvlText.text = currentLvl.ToString();
        expeImage.fillAmount = currentExperience / expTNL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void expModifier(float experience) //cuando se complete la experiencia necesaria
    {
        currentExperience += experience;
        expeImage.fillAmount = currentExperience / expTNL;


        if(currentExperience >= expTNL)
        {
            expTNL = expTNL * 2; //se duplica el nivel 
            currentExperience = 0; //reinicia la barra de experiencia al subir de nivel
            PlayerHealth.instance.maxHealth += 35f;
            currentLvl ++;
            crrLvlText.text = currentLvl.ToString();
            
        }
    }



}
