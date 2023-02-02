using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockActions : MonoBehaviour
{
    PlayerMovement playerScript;
    float move = 0;
    float startPos;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        startPos = transform.position.y; 

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * move);
        if(transform.position.y < startPos)
        {
            move = 0;
            transform.position = new Vector3(transform.position.x, startPos, transform.position.z);
        }

        if(transform.position.y > startPos + 1)
        {
            move = -15;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && transform.position.y > collision.transform.position.y && !playerScript.onGround)
        {
            move = 15;
        }
    }
}
