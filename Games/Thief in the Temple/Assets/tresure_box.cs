using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tresure_box : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triger hit gold??");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("gold!!");
            RPGGameManager.sharedInstance.treasureFound = true;
            Destroy(gameObject);
        }
    }

}
