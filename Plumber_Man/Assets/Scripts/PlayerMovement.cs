using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody player_rb;
    private Rigidbody block_rb;
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    int speed = 10;
    float horizontalInput;
    float verticalInput;
    public int jump = 15;
    public bool onGround = true;
    private Quaternion forwardRotation = new Quaternion(0,0,0,0);
    private Quaternion backwardRotation = new Quaternion(0,180,0,0);
    private Animator upDown;
    public float gravity = -27;
    private bool subSurf = false;
    bool letsGo = true;
    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
        block_rb = GameObject.Find("Block").GetComponent<Rigidbody>();
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
        upDown = GameObject.Find("Block").GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -27, 0);
        verticalInput = 0;
        speed = 10;
        if (onGround)
        {
            player_rb.velocity = new Vector3(0, -3, 0);
        }
        if (transform.position.z <= camera1.transform.position.z + 7.5){
            camera1.enabled = false;
            camera2.enabled = true;
        }
        if (transform.position.z >= camera2.transform.position.z - 7.5){
            camera2.enabled = false;
            camera1.enabled = true;
        }

        if (subSurf)
        {
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround){
            player_rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            onGround = false;
            
        }
        if (Input.GetKey(KeyCode.S)){
            verticalInput = 1;
            transform.rotation = backwardRotation;
        }
        if (Input.GetKey(KeyCode.W)){
            verticalInput = 1;
            transform.rotation = forwardRotation;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20;
        }
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        
        upDown.SetBool("Bounce_bool", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Top Collider"))
        {
            onGround = true;
            
        }

       
        
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Ground Bound"))
        {
            onGround = false;
        }
        if (other.gameObject.CompareTag("Sub Surface Check"))
        {
            subSurf = true;
        }
        if (other.gameObject.CompareTag("Upper Check"))
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;
            subSurf = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
    }


}
