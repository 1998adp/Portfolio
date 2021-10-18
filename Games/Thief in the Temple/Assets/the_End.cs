using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class the_End : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && RPGGameManager.sharedInstance.treasureFound )
        {

            RPGGameManager.sharedInstance.showVictory();

        }

    }
}
