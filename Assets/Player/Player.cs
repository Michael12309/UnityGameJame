using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // private float alpha = .05f;
    // private Vector2 acc; //acceleration
    // private Vector2 velocity;
    // private Rigidbody2D rb;
    // //private float rotationSpeed = 5;
    // private float rotation_x;

    private float thrustInput;
    private float turnInput;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMovevemt(InputAction.CallbackContext action)
    {
        thrustInput = action.ReadValue<Vector2>().y;
        
        //float radians = (transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad;
        //acc = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * alpha * action.action.ReadValue<Vector2>().y;
    }

    public void OnRotation(InputAction.CallbackContext action)
    {
        turnInput = action.ReadValue<Vector2>().x;
    }

    // Update is called once per frame
    void Update()
    {
        //velocity += acc;
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * thrustInput);
        //rb.AddTorque(-turnInput);
    //     rb.velocity = velocity;
         rb.MoveRotation(rb.rotation + -turnInput);// * Time.fixedDeltaTime * 85);
    }
}
