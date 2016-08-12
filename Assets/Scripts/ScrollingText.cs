using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScrollingText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.up * Time.deltaTime*10);
        if (this.transform.position.y > 500)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
	}
}
