using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

    public float translateSpeed = 10f;
    public float rotateSpeed = 100f;
    public float acceleration = 0.01f;

    private perspectiveChanger perspective;

	// Use this for initialization
	void Start () {
        perspective = GameObject.Find("Level").GetComponent<perspectiveChanger>();
	}
	
	// Update is called once per frame
	void Update () {
        if (perspective.FPS == true)
        {
            float translation = Input.GetAxis("Vertical") * translateSpeed;
            float rotation = Input.GetAxis("Horizontal") * rotateSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);

            if (translation != 0)
            {
                if (translateSpeed < 10)
                {
                    translateSpeed += acceleration;
                }

            }
            else
            {
                translateSpeed = 1f;
            }
        }

	}
}
