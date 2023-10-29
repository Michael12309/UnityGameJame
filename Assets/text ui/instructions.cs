using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class instructions : MonoBehaviour
{
    public TMP_Text text;  //Add reference to UI Text here via the inspector    
    public float timeToDisappear1 = 15f;
    public float timeToDisappear2 = 27f;
    public float timeToDisappear3 = 20f;

    //Call to enable the text, which also sets the timer
    public void Start()
    {
        text.enabled = true;
    }

    //We check every frame if the timer has expired and the text should disappear
    void Update()
    {
        string final = "";
        if (Time.time < timeToDisappear1)
        {
            final = "Your crew is on a mission to visit five distinct planets, each possessing a vital element crucial to their species' survival. Uniting these planetary resources is the key to your interstellar journey home.";
        }
        else if (Time.time < timeToDisappear2)
        {
            final = "Safely and carefully land on each planet to refuel.";
        }
        else
        {
            text.enabled = false;
        }

        text.text = final;
    }
}
