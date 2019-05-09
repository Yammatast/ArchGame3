using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Health
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public bool damaged;

    public float speed;
    public Text start, end, ammoText, healthText;
    private Rigidbody rb;
    private int ammo;
    private int health;
    private bool gameEnded;
    int startValue = 100;

    AudioSource dmgTaken; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        start.text = "START";
        end.text = "";
        ammo = 5;
        SetAmmoText();
        health = 9;
        SetHealthText();
        gameEnded = false;
        dmgTaken = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    [System.Obsolete]
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
        if (!gameEnded)
        {

            if (Input.GetKey(KeyCode.W))
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
        if(Input.GetKey(KeyCode.K))
        {
            Application.LoadLevel(0);
        }

    }

    void SetAmmoText()
    {
        ammoText.text = "Ammo left: " + ammo.ToString();

    }

    void SetHealthText()
    {
        healthText.text = "Health: ";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            end.text = "YOU HAVE REACHED THE GOAL!\n    PRESS 'K' TO RESTART";
            gameEnded = true;
        }

        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            ammo += 5;
            SetAmmoText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            healthSlider.value = health;

            dmgTaken.Play();

            if (health == 0)
            {
                damageImage.color = flashColor;
                end.text = "  YOU HAVE LOST\n    PRESS 'K' TO RESTART";
                gameEnded = true;
            }


        }
    }


}
