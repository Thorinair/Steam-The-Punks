using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

    public float translateSpeed = 10f;
    public float rotateSpeed = 100f;

	// Use this for initialization
	void Start () {
        //Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * translateSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotateSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
	}
}
