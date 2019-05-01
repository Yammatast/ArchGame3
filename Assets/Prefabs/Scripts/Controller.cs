using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /**
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        */
        if (Input.GetKey (KeyCode.W))
        {
            transform.position += transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -2, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 2, 0);
        }
    }
}
