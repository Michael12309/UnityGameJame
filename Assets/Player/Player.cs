using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMovevemt(InputAction.CallbackContext action)
    {
        print("YO");
        print(action);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
