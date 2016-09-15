using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    private bool menuToggle=false;
    public GameObject menuScreen;

	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetKeyDown(KeyCode.Escape)){
            menuToggle=!menuToggle;
            if (menuToggle == false)
            {
                menuScreen.SetActive(false);
            }
            else
            {
                menuScreen.SetActive(true);
            }
        }
              
	}

    public void Resume()
    {
        menuToggle=false;
        menuScreen.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
