using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIceMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
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
            rb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
        }

        if (!collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
