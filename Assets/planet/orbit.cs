using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour
{
    public GameObject target;
    public float orbitSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(0f, 0f, 1f), orbitSpeed * Time.deltaTime);        
    }
}