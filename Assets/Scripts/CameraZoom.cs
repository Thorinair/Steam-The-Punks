using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    public float zoomSensitivity = -20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && this.transform.position.y >=50.9f)
        {
            transform.Translate(Vector3.up * Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && this.transform.position.y <= 90.9f)
        {
            transform.Translate(Vector3.up * Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity);
        }

	}
}
