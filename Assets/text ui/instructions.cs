using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class instructions : MonoBehaviour
{
    public TMP_Text text;  //Add reference to UI Text here via the inspector
    private float timer = 0f;
    public float timeToDisappear = 20f;

    //Call to enable the text, which also sets the timer
    public void Start()
    {
        text.enabled = true;
    }

    //We check every frame if the timer has expired and the text should disappear
    void Update()
    {
        print(Time.time);

    }
}
