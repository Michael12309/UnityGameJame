using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class good_landing : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text planet_text;

    public float fadetime;
    public bool fadingin;
    public bool fadingin_fail_win;
    public bool succ = false;
    void Start()
    {
        planet_text.CrossFadeAlpha(0, 0.0f, false);
        fadetime = 0;
        fadingin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingin)
        {
            FadeIn();
        }
        else if (planet_text.color.a != 0)
        {

            planet_text.CrossFadeAlpha(0, 0.5f, false);


        }

        if (fadingin_fail_win)
        {
            FadeIn();
        }
        else if (planet_text.color.a != 0)
        {

            planet_text.CrossFadeAlpha(0, 0.5f, false);


        }
    }


    void FadeIn()
    {


        planet_text.CrossFadeAlpha(1, 0.0f, false);
        fadetime += Time.deltaTime;
        if (planet_text.color.a == 1 && fadetime > 1.5f)
        {

            fadingin = false;
            fadetime = 0;

        }


    }

 
    
}
