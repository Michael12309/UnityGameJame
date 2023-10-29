using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class planetfade : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text planet_text;


    public float fadetime;
    public bool fadingin;
 
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
        else if (planet_text.color.a != 0) {

            planet_text.CrossFadeAlpha(0, 0.5f, false);


        }

    }


    void FadeIn() {


        planet_text.CrossFadeAlpha(1, 0.0f, false);
        fadetime += Time.deltaTime;
        if (planet_text.color.a == 1 && fadetime > 1.5f) {

            fadingin = false;
            fadetime = 0;

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planet") {

            fadingin = true;
            planet_text.text = collision.name;
        }
    }
}
