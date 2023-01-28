using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFollowPlayer : MonoBehaviour
{
   
    public GameObject player;
    private int speed = 10;
    private int bspeed = -10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= transform.position.z + 15){
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (player.transform.position.z <= transform.position.z + 7){
            transform.Translate(Vector3.forward * Time.deltaTime * bspeed);
        }
    }
}
