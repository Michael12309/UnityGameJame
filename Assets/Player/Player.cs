using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float alpha = .05f;
    private Vector2 acc; //acceleration
    private Vector2 velocity;
    private Rigidbody2D rb;
    //private float rotationSpeed = 5;
    private float rotation_x;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMovevemt(InputAction.CallbackContext action)
    {
        print("YO");

        transform.position += Vector3.forward;


    }

    public void OnRotation(InputAction.CallbackContext action)
    {
        rotation_x = action.ReadValue<Vector2>().x;
        print("rotation");
        

    }

    // Update is called once per frame
    void Update()
    {
        velocity += acc;
        rb.MovePosition(rb.position + velocity * Time.deltaTime);

        rb.MoveRotation(rb.rotation += rotation_x);






    }
}
