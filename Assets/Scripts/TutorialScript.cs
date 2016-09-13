using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
	}
}
