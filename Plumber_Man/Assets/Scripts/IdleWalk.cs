using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalk : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 5;
    private Quaternion forwardRotation = new Quaternion(0, 0, 0, 0);
    private Quaternion backwardRotation = new Quaternion(0, 180, 0, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Upper Check") && transform.rotation.y == 0)
        {
            transform.rotation = backwardRotation;
        }

        if (other.gameObject.CompareTag("Upper Check") && transform.rotation.y == 180)
        {
            transform.rotation = forwardRotation;
        }
    }
}
