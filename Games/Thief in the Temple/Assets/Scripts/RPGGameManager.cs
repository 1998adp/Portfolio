using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    public SpawnPoint playerSpawn;
    public RPGCameraManager cam;
    public bool treasureFound;
    public GameObject endPoint;
    public GameObject UIprefab;
    private GameObject UI;

    public static RPGGameManager sharedInstance = null;

    public void Awake()
    {
        if(sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void SetupScene()
    {
        SpawnPlayer();
        SetupUI();
    }

   public void SpawnPlayer()
    {
        if(playerSpawn != null)
        {
            GameObject MC = playerSpawn.SpawnObject();
            cam.VirtualCamera.Follow = MC.transform;
        }
    }

    public void SetupUI()
    {
        
        UI = Instantiate(UIprefab, transform.position, Quaternion.identity);

    }

    public void showVictory()
    {
        UI.SetActive(true);
        Time.timeScale = 0;
    }


}
