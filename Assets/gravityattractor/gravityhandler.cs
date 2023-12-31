using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gravityhandler : MonoBehaviour
{
    public restart rest;
    private bool is_visited = false;
    private bool crash_count = false;
    private Rigidbody2D rb;
    private Rigidbody2D ply_rb; //Player rb
    public Player player;
    public float degreeThreshold = 10;
    public float speedThreshold = .35f;
    [SerializeField] float revSpeed = 7f;
    [SerializeField] public float mass = 1; //radius  * 2

    public AudioSource crash;
    public AudioSource land;

    private SpriteRenderer minimapSprite;


    //public good_landing lander_text;

    private float gravityDampener = 0.2f;
    public static float k = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = player.GetComponent<Player>();

        //lander_text = lander_text.GetComponent<good_landing>();

        ply_rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>(); //only one instance must exist for this to work

        minimapSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    public void AddGravityForce(Rigidbody2D target)
    {
        float distance = Vector3.Distance(rb.position, target.position);
        if (distance <= 1000)
        {
            float massprod = mass * target.mass * k;



            float magnitude = (massprod / Mathf.Pow(distance, 2)) * k;

            Vector3 difference = rb.position - target.position;
            Vector3 forceDir = difference.normalized;
            Vector3 forceVector = forceDir * magnitude;

            target.AddForce(forceVector * gravityDampener);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("OnCollisionEnter2D");

        WinLose(col);

    }

    public void WinLose(Collision2D col)
    {
        //calculate the angle between the players rotation and the circles tangent at the players position
        if (player.landed == false && player.is_dead == false)
        {
            Vector2 point = rb.ClosestPoint(ply_rb.position);
            //print(point);
            ////float slope_angle = Mathf.Deg2Rad * Mathf.Atan(- ((rb.centerOfMass.x - point.x)/ (rb.centerOfMass.y - point.y))) ; //in degrees
            //float slope_angle = Vector3.Angle(point.normalized, Vector3.up);
            //float deg_diff = Mathf.Abs( Mathf.Abs(slope_angle) - (Mathf.Abs( ply_rb.rotation) % 180));


            //print("rotation:");
            //print(ply_rb.rotation);
            //print("----");
            //print(slope_angle);
            //print(deg_diff);
            //print("----");
            ////Vector3 normal = (.position - transform.position).normalized;
            ////Vector3 up = new Vector3(0, 0, 1); // up side of your circle
            ////Vector3 tangent = Vector3.Cross(normal, up);
            //if (ply_rb.velocity.magnitude < .09 && deg_diff <= 18)
            //{
            //    //print(ply_rb.velocity.magnitude);
            //    Debug.Log("win");
            //}
            //else
            //{
            //    //print(ply_rb.velocity.magnitude);
            //    Debug.Log("lose");
            //}

            Vector2 centerToEdge = rb.worldCenterOfMass - point;
            //print(point);
            centerToEdge.Normalize();

            //print("center to edge");
            centerToEdge = -centerToEdge;
            //print(centerToEdge);
            var ang = Mathf.Asin(centerToEdge.x) * Mathf.Rad2Deg;
            if (centerToEdge.y < 0)
            {
                ang = 180 - ang;
            }
            else
            {
                if (centerToEdge.x < 0)
                {
                    ang = 360 + ang;
                }
            }

            float playerAngle = 360 - ply_rb.transform.rotation.eulerAngles.z;
            //print("hit angle:    " + ang);
            //print("player angle: " + playerAngle);
            //print("speed:  " + ply_rb.velocity.magnitude);
            float degreeDifference = Mathf.Abs(playerAngle - ang);

            if (ply_rb.velocity.magnitude <= speedThreshold && (degreeDifference <= degreeThreshold || degreeDifference >= (360 - degreeThreshold)))
            {
                //print(ply_rb.velocity.magnitude);
                if (is_visited == false)
                {
                    player.fuel += 75;
                    is_visited = true;
                    print("now visited");
                    player.planet_count += 1;
                    player.visit_fade = true;

                    land.Play();
                    minimapSprite.color = new Color(208f / 255f, 129f / 255f, 89f / 255f, 255f / 255f);
                    
                }
                print("win");
                player.landed = true;


                //lander_text.planet_text.text = "The Eagle has landed!";
            }
            else
            {
                //print(ply_rb.velocity.magnitude);
                Debug.Log("lose");
                if (crash_count == false)
                {
                    crash.Play();
                    crash_count = true;
                }

                player.landed = true;
                player.is_dead = true;
                player.sr.sprite = player.sprite_dead;

                rest.Setup();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AddGravityForce(ply_rb);
        rb.MoveRotation(rb.rotation + revSpeed * Time.fixedDeltaTime);
    }
}
