using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    public TMP_Text text;

    public int planet_count = 0;

    //public TMP_Text visit_text;
    public bool visit_fade = false;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;

    [SerializeField]
    public float dampener = 0.4f;
    [SerializeField]
    public float turnSpeed = 1.2f;

    [SerializeField]
    public float fuel = 230f;
    private float fuelDecrease = 0f;

    private float thrustInput;
    private float turnInput;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private int thrustAmount = 0;

    private Vector2 calculatedAcceleration = Vector2.zero;
    private Vector2 lastVelocity = Vector2.zero;

    public AudioSource thrustAudio;

    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();

        InvokeRepeating("UpdateText", 0, 0.1f);
    }

    public void OnMovevemt(InputAction.CallbackContext action)
    {
        if (action.performed && fuel > 0)
        {
            thrustInput = action.ReadValue<Vector2>().y;
            thrustAmount += (int)thrustInput;
            thrustAmount = (int)Mathf.Clamp((float)thrustAmount, 0f, 3f);

            //float radians = (transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad;
            //acc = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * alpha * action.action.ReadValue<Vector2>().y;

            if (thrustAmount == 0)
            {
                fuelDecrease = 0f;
                sr.sprite = sprite1;
            }
            if (thrustAmount == 1)
            {
                fuelDecrease = 0.40f;
                sr.sprite = sprite2;
            }
            if (thrustAmount == 2)
            {
                fuelDecrease = 0.60f;
                sr.sprite = sprite3;
            }
            if (thrustAmount == 3)
            {
                fuelDecrease = 1.0f;
                sr.sprite = sprite4;
            }
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
        if (fuel <= 0)
            thrustAmount = 0;

        rb.AddRelativeForce(Vector2.up * thrustAmount * dampener);
        rb.MoveRotation(rb.rotation + -turnInput * turnSpeed);
    }

    void UpdateText()
    {
        calculatedAcceleration = (rb.velocity - lastVelocity) / Time.deltaTime;
        lastVelocity = rb.velocity;
        if (fuel <= 0)
        {
            fuel = 0;
            sr.sprite = sprite1;
        }
        else
        {
            fuel -= fuelDecrease;
        }

        text.text = "Fuel:                       " + fuel.ToString("F2") + "\n" +
                    "Velocity:              " + rb.velocity + "\n" +
                    "Acceleration:  " + calculatedAcceleration;

        if (fuelDecrease > 0f)
        {
            thrustAudio.volume = fuelDecrease / 4f;
            thrustAudio.Play();
        }
        else
        {
            thrustAudio.Stop();
        }

    }
}
