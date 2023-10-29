using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class good_landing : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text planet_text;


    public Player player;

    public float fadetime;
    void Start()
    {
        planet_text.text = "The Eagle has landed! Planet visited!";
        planet_text.CrossFadeAlpha(0, 0.0f, false);
        player = player.GetComponent<Player>();
        fadetime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.visit_fade)
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

            player.visit_fade = false;
            fadetime = 0;

        }


    }

 
    
}
