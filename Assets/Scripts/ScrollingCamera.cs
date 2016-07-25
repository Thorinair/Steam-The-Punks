using UnityEngine;
using System.Collections;

public class ScrollingCamera : MonoBehaviour {

    public Transform camera;
    public float speed = 1f;
    public bool startMoving;
    Vector3 direction;
	
	// Update is called once per frame
	void Update () {
        if (startMoving)
        {
            camera.position += direction;
        }
	}
    public void StartMovingForward(bool opposite)
    {
        startMoving = true;
        direction = (!opposite) ? camera.forward : -camera.forward;
        direction *= speed;
    }
    public void StartMovingSides(bool opposite)
    {
        startMoving = true;
        direction = (!opposite) ? camera.right : -camera.right;
        direction *= speed;
    }
    public void StopMoving()
    {
        startMoving = false;
    }
}
