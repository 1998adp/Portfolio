using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{

    public GameObject Button;
    public GameObject background;
    public GameObject bridge;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Button.SetActive(true);
            background.SetActive(false);
            bridge.SetActive(true);
        }
    }
}
