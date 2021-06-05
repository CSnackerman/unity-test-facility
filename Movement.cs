using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float max_speed = 10.0f;
    public Vector3 velocity;
    public Camera maincamera;
    private Quaternion camRot;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        velocity = new Vector3(0,0,0);
        transform.position = new Vector3(0, 1.5f, 0);

        // point the camera
        camRot = maincamera.transform.rotation;
        transform.eulerAngles = new Vector3(0, camRot.eulerAngles.y, 0);
    }

    // Update is called once per frame
    void Update()
    {   
        if (camRot != maincamera.transform.rotation)
        {
            camRot = maincamera.transform.rotation;
            transform.eulerAngles = new Vector3 (0, camRot.eulerAngles.y, 0);

            Debug.Log("rotation = " + camRot.eulerAngles);
        }

        velocity.x = 0;
        velocity.y = 0;
        velocity.z = 0;

        if (Input.GetKey (KeyCode.W))
        {
            velocity += maincamera.transform.forward;
        }
        if (Input.GetKey (KeyCode.S))
        {
            velocity += -maincamera.transform.forward;
        }

        if (Input.GetKey (KeyCode.A))
        {
            velocity += -maincamera.transform.right;
        }
        if (Input.GetKey (KeyCode.D))
        {
            velocity += maincamera.transform.right;
        }

        velocity.y = 0;

        //Debug.Log(velocity.normalized * max_speed);
        //rb.MovePosition(transform.position + velocity.normalized * max_speed * Time.deltaTime);
        //transform.position += velocity.normalized * max_speed * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        transform.position += velocity.normalized * max_speed * Time.deltaTime;
    }
}
