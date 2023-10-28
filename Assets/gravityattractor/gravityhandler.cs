using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gravityhandler : MonoBehaviour
{

    private Rigidbody2D rb;
    private Rigidbody2D ply_rb; //Player rb
    private Player player;
    static float k = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        ply_rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>(); //only one instance must exist for this to work
    }
    public void AddGravityForce(Rigidbody2D target)
    {
        float distance = Vector3.Distance(rb.position, target.position);
        print(distance);
        if (distance <= 10)
        {
            float massprod = rb.mass * target.mass * k;



            float magnitude = (massprod / Mathf.Pow(distance, 2)) * k;

            Vector3 difference = rb.position - target.position;
            Vector3 forceDir = difference.normalized;
            Vector3 forceVector = forceDir * magnitude;

            target.AddForce(forceVector);
        }

    }

    // Update is called once per frame
    void Update()
    {
        AddGravityForce(ply_rb);
    }
}
