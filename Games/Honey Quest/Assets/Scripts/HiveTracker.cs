 using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
 
 public class HiveTracker : MonoBehaviour
{

    // Initialization
    int hivesLeft = 0;
    public static bool sHives;

    void Start()
    {
        hivesLeft = 1; 

    }

    // Keeps track of hives left
    void Update()
    {
        GameObject[] hives = GameObject.FindGameObjectsWithTag("CanBePickedUp");
        hivesLeft = hives.Length;
        if (Input.GetKeyDown(KeyCode.A))
        {
            hivesLeft--;
        }
        if (hivesLeft == 0)
        {
           sHives= true;
        }
    }

    //Message to player to help them keep track of hives remaining on the map for victory condition.
    void OnGUI()
    {
        var virtualWidth = 1920;
        var virtualHeight = 1080;
        GUIStyle headStyle = new GUIStyle();
        headStyle.fontSize = 24;

        if (hivesLeft == 0)
        {
            GUI.Label(new Rect(Screen.width/virtualWidth, Screen.height/virtualHeight, 500, 400), "All gone!", headStyle);
        }
        else
        {
            GUI.Label(new Rect(Screen.width/virtualWidth, Screen.height/virtualHeight, 500, 400), "Hives left:" + hivesLeft, headStyle);
        }
    }

}