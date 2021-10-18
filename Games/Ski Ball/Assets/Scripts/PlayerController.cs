using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private static Rigidbody playerRb;
    public float speed = 5;
    public float rotationSpeed = 50;

    private int limit = -98;
    public int score = 0;

    public ParticleSystem fireworksParticle;
    AudioSource audioSrc;

    float holdTime;
    float chargeForce = 0;
    float chargeRate = 1;
    float minForce = .3f;
    float maxForce = 2;
    bool charging = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        //spin the ball
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        //catch out of bounds
        if (transform.position.y < -30)
        {
            fireworksParticle.Play();
            Destroy(gameObject, .7f);
        }
        
        //checks charging
        if (Input.GetKeyDown(KeyCode.Space) && (transform.position.x < limit))
        {
            //start chargeing
            charging = true;
        }

        //this adds the charge
        if (charging == true)
        {
            //add charge rate to charge damage every sec
            chargeForce = (chargeForce + (chargeRate * Time.deltaTime));
        }

        //this resets and fires
        if (Input.GetKeyUp(KeyCode.Space) && (transform.position.x < limit))
        {
            audioSrc.Play();
            //Fire
            //==reset==
            if (chargeForce > maxForce)
            {
                chargeForce = maxForce;
            }
            if (chargeForce == minForce || chargeForce < minForce)
            {
                chargeForce = ((minForce + 1) / 100) * 16;
            }
            playerRb.AddForce(Vector3.right * speed * chargeForce);
            chargeForce = 0;
            charging = false;
        }

        //force horizontal left
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (transform.position.x < limit))
        {
            playerRb.AddForce(Vector3.forward * speed / 10);
        }

        //force horizontal right
        if (Input.GetKeyDown(KeyCode.RightArrow) && (transform.position.x < limit))
        {
            playerRb.AddForce(Vector3.back * speed / 10);
        }
    }
}
