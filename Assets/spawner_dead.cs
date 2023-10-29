using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_dead : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deaddudes;
    public Player player;
    private bool once = false ;
    void Start()
    {
        //Instantiate(deaddudes);
    }

    // Update is called once per frame
    void Update()
    {
        if (once == false && player.is_dead) {
            
            Instantiate(deaddudes, new Vector3(player.transform.position.x - .5f, player.transform.position.y - .5f, player.transform.position.z + .5f), player.transform.rotation);
            Instantiate(deaddudes, new Vector3(player.transform.position.x - .5f, player.transform.position.y + .5f, player.transform.position.z - .5f), player.transform.rotation);
            Instantiate(deaddudes, new Vector3(player.transform.position.x + .5f, player.transform.position.y + .5f, player.transform.position.z + .5f), player.transform.rotation);
            Instantiate(deaddudes, new Vector3(player.transform.position.x + .5f, player.transform.position.y - .5f, player.transform.position.z - .5f), player.transform.rotation);
            once = true;

        }
        
    }
}
