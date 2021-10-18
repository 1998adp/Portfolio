using UnityEngine.SceneManagement;
using UnityEngine;

public class Escape : MonoBehaviour
{
    // Update is called once per frame
    public void Update()
    {
        // Exit the application if the user presses the "escape" key
        // Does not work when playing from inside the Unity editor
        if (Input.GetKey("escape"))
        {
            Debug.Log("Leaving to main menu");
            SceneManager.LoadScene(0);
        }

    }
}
