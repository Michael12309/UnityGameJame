using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float alpha = .1f;
    private Vector2 acc; //acceleration
    private Vector2 velocity;
    public Rigidbody2D rb;
    //private float rotationSpeed = 5;
    private float rotation_x;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void OnMovevemt(InputAction.CallbackContext action)
    {
        print(transform.rotation.eulerAngles.z);
        float radians = (transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad;
        print(radians);
        print(Mathf.Cos(radians) + "   :   " + Mathf.Sin(radians));
        acc = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * alpha * action.action.ReadValue<Vector2>().y;
    }

    public void OnRotation(InputAction.CallbackContext action)
    {
        rotation_x = action.ReadValue<Vector2>().x;
        print("rotation");
        

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("here");
        rb.velocity = new Vector2(0.0f, 0.0f);
        rb.angularVelocity = 0f;
        rb.rotation = 0.0f;
    }

    void Update()
    {
        velocity += acc;
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation -rotation_x * Time.deltaTime * 150);
    }
}
