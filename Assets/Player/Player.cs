using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;

    [SerializeField]
    public float dampener = 0.2f;

    private float thrustInput;
    private float turnInput;
    
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private int thrustAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    public void OnMovevemt(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            thrustInput = action.ReadValue<Vector2>().y;
            thrustAmount += (int)thrustInput;
            thrustAmount = (int)Mathf.Clamp((float)thrustAmount, 0f, 3f);
            
            //float radians = (transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad;
            //acc = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * alpha * action.action.ReadValue<Vector2>().y;
            if (thrustAmount == 0)
                sr.sprite = sprite1;
            if (thrustAmount == 1)
                sr.sprite = sprite2;
            if (thrustAmount == 2)
                sr.sprite = sprite3;
            if (thrustAmount == 3)
                sr.sprite = sprite4;
        }
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
        rb.AddRelativeForce(Vector2.up * thrustAmount * dampener);
        rb.MoveRotation(rb.rotation + -turnInput);
    }
}
