using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockActions : MonoBehaviour
{
    PlayerMovement playerScript;
    Animator blockAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        blockAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.onGround)
        {
            blockAnim.ResetTrigger("Bounce");
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && transform.position.y > collision.transform.position.y && !playerScript.onGround)
        {
            blockAnim.SetTrigger("Bounce");
        }
    }
}
