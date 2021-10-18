using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public int holeValue = 0;
    public Text scoreReference;
    public AudioSource audioSource;

    public ParticleSystem fireworksParticle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Manage hole functions
    void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        fireworksParticle.Play();
        Destroy(other.gameObject);
        scoreReference.text = (int.Parse(scoreReference.text) + holeValue).ToString();
    }
}
