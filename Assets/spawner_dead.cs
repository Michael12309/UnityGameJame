using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_dead : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deaddudes;
    public Player player;
    public 
    void Start()
    {
        player = player.GetComponent<Player>();
        //Instantiate(deaddudes);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.is_dead) {

            Instantiate(deaddudes,player.transform.position, player.transform.rotation);
            Instantiate(deaddudes, player.transform.position, player.transform.rotation);
            Instantiate(deaddudes, player.transform.position, player.transform.rotation);
            Instantiate(deaddudes, player.transform.position, player.transform.rotation);


        }
        
    }
}
