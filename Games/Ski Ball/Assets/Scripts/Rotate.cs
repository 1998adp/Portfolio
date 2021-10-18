using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float xSpeed = 0.0f;
    public float ySpeed = 0.0f;
    private float zSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Rotate Skydome
    void Update()
    {
        transform.Rotate(
           xSpeed * Time.deltaTime,
           ySpeed * Time.deltaTime,
           zSpeed * Time.deltaTime
      );
    }
}
