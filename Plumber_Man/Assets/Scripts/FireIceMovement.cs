using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIceMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    PlayerMovement playerScript;
    GameObject player;
    float fireSpeed = 10;
    private Quaternion forwardRotation = new Quaternion(0, 0, 0, 0);
    private Quaternion backwardRotation = new Quaternion(0, 180, 0, 0);
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        if (player.transform.rotation == backwardRotation)
        {
            fireSpeed = -10;
        }

        rb.AddForce(Vector3.forward * fireSpeed, ForceMode.Impulse);


    }

    // Update is called once per frame
    void Update()
    {
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.AddForce(Vector3.up * 8, ForceMode.Impulse);
            rb.AddForce(Vector3.forward * fireSpeed, ForceMode.Impulse);   
        }

        if (!collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        
    }
}
