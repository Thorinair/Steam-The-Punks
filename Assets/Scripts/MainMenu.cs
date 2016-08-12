using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void OnMouseUp()
    {
        print("clicked");
        if (this.tag == "play")
            SceneManager.LoadScene("Level1");
        else if (this.tag == "about")
            SceneManager.LoadScene("Credits");
        else if (this.tag == "quit")
            Application.Quit();
    }
}
