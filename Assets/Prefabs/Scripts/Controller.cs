﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public Text start, end, pickUpText;
    private int countPickUps;
    private Rigidbody rb;
    int startValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        start.text = "START";
        end.text = "";
        countPickUps = 3;
        SetPickUpText();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        startValue -= 1;
        if (startValue <= 0)
        {

            start.text = "";
        }
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

    void SetPickUpText()
    {
        pickUpText.text = "Pick Ups left: " + countPickUps.ToString();

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            end.text = "YOU HAVE REACHED THE GOAL!";
        } 
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            countPickUps -= 1;
            SetPickUpText();
        }
        // if() {} om man rör vid en enemy
    }
}
