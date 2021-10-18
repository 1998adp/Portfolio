
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Management : MonoBehaviour
{
    public GameObject playerPrefab;
    public int ballsLeft = 5;
    public GameObject GameOverObject;
    public int gameOver = 0;

    // Start is called before the first frame update
    void Start()
    {
        ballsLeft--;
        spawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //Update GUI for ball count
        if (GameObject.Find("Player(Clone)") == null && ballsLeft > 0)
        {
            spawnPlayer();
            ballsLeft--;
            Text ballText = GameObject.Find("BallsLeftNo").GetComponent<Text>();
            ballText.text = ballsLeft.ToString();
        }

        // Exit the application if the user presses the "escape" key
        // Does not work when playing from inside the Unity editor
        if (Input.GetKey("escape"))
        {
            Debug.Log("Exiting game");
            Application.Quit();
        }

        //Restart the game if user presses r key
        if (Input.GetKey("r"))
        {
            Debug.Log("Restarting game");
            SceneManager.LoadScene(1);
        }

        //GameOver
        if(GameObject.Find("Player(Clone)") == null && ballsLeft == 0)
        {
            GameOverObject.SetActive(true);
        }
    }
    
    //Spawn player
    void spawnPlayer()
    {
        Instantiate(playerPrefab, new Vector3(-98.56f, 18.15f, -15.1f), playerPrefab.transform.rotation);
    }
}
