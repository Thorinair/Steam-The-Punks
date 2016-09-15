using UnityEngine;
using System.Collections;

public class ScrollingCamera : MonoBehaviour {

    public Transform camera;
    public float speed = 0.5f;
    public bool startMoving;
    Vector3 direction;
    int side = 0;
	
	// Update is called once per frame
	void Update () {
        if (startMoving) {
            if ((camera.position.z < 330 && side == 1) ||
                (camera.position.z > 70 && side == 2) ||
                (camera.position.x < -120 && side == 3) ||
                (camera.position.x > -360 && side == 4)) {
                camera.position += direction;
            }
        }
	}
    public void StartMovingForward(bool opposite)
    {
        startMoving = true;
        direction = (!opposite) ? camera.forward : -camera.forward;
        direction *= speed;
        side = (!opposite) ? 1 : 2;
    }
    public void StartMovingSides(bool opposite)
    {
        startMoving = true;
        direction = (!opposite) ? camera.right : -camera.right;
        direction *= speed;
        side = (!opposite) ? 3 : 4;
    }
    public void StopMoving()
    {
        startMoving = false;
    }
}
