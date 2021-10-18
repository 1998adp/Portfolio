using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Options present on the main menu

    //Loads the main game scene
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void InfMode()
    {
        SceneManager.LoadScene(2);
    }
    // Exits the game
    public void QuitGame()
    {
        Debug.Log("Leaving game!");
        Application.Quit();
    }
}
