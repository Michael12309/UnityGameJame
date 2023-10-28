using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float thrustInput;
    private float turnInput;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
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

    void Update()
    {
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * thrustInput);
         rb.MoveRotation(rb.rotation + -turnInput);
    }
}
