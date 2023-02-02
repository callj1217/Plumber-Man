using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalk : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 5;
    bool backwards = false;
    PlayerMovement playerScript;
    private Quaternion forwardRotation = new Quaternion(0, 0, 0, 0);
    private Quaternion backwardRotation = new Quaternion(0, 180, 0, 0);
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (backwards)
        {
            transform.rotation = backwardRotation;
        }
        else
        {
            transform.rotation = forwardRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Upper Check"))
        {
            backwards = !backwards;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player") && playerScript.hasFire && transform.position.y + 1 > collision.gameObject.transform.position.y)
        {
            backwards = !backwards;
            playerScript.hasFire = false;
            playerScript.immortal = true;
            StartCoroutine(playerScript.Wait());
        }
        else if (collision.gameObject.CompareTag("Player") && playerScript.isBig && !playerScript.immortal && transform.position.y + 1 > collision.gameObject.transform.position.y)
        {
            backwards = !backwards;
            playerScript.isBig = false;
            playerScript.immortal = true;
            StartCoroutine(playerScript.Wait());
        }

        
    }
}
