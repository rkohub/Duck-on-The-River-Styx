using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject camera;
    public Vector3 posDiff;
    public Vector3 forwardDir;
    public Vector3 rightDir;
    private Rigidbody rb;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        //Get the first child under this game object
        camera = this.gameObject.transform.GetChild(0).gameObject;

        speed = 3;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        posDiff = camera.transform.position - transform.position;
        posDiff.y = 0;
        forwardDir = -posDiff;
        rightDir = new Vector3(forwardDir.z, 0, -forwardDir.x);


        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forwardDir * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-rightDir * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-forwardDir * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(rightDir * speed);
        }

        //print(posDiff);

    }
}