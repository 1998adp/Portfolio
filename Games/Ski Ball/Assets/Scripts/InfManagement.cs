
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfManagement : MonoBehaviour
{
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //Update GUI for ball count
        if (GameObject.Find("Player(Clone)") == null)
        {
            spawnPlayer();
        }

        // Exit the application if the user presses the "escape" key
        // Does not work when playing from inside the Unity editor
        if (Input.GetKey("escape"))
        {
            Debug.Log("Exitting game");
            Application.Quit();
        }

        //Restart the game if user presses r key
        if (Input.GetKey("r"))
        {
            Debug.Log("Restarting game");
            SceneManager.LoadScene(2);
        }

    }
    
    //Spawn player
    void spawnPlayer()
    {
        Instantiate(playerPrefab, new Vector3(-98.56f, 18.15f, -15.1f), playerPrefab.transform.rotation);
    }
}
