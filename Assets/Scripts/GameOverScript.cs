using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
