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

        print(transform.rotation);

        print(transform.rotation.w);
        print("--");
        print(transform.rotation.z);

        //acc = new Vector2(transform.rotation.w, transform.rotation.z) * action.action.ReadValue<Vector2>().y * alpha;
        float radians = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
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
    void Update()
    {
        velocity += acc;
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -rotation_x) * Time.deltaTime * 50, Space.World);
    }
}
