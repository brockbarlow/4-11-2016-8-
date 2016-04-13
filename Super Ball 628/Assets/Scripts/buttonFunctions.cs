using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour {

    public void startGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void learnGame()
    {
        SceneManager.LoadScene("Controls");
    }

    public void leaveGame()
    {
        Application.Quit();
    }

    public void backToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}