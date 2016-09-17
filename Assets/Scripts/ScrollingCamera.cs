using UnityEngine;
using System.Collections;

public class ScrollingCamera : MonoBehaviour {

    public Transform cameraObj;
    public float speed = 5f;
    public bool startMoving;
    Vector3 direction;
    int side = 0;
	
	// Update is called once per frame
	void Update () {
        if (startMoving) {
            if ((cameraObj.position.z < 330 && side == 1) ||
                (cameraObj.position.z > 70 && side == 2) ||
                (cameraObj.position.x < -120 && side == 3) ||
                (cameraObj.position.x > -360 && side == 4)) {
                cameraObj.position += direction * Time.deltaTime;
            }
        }
	} 
    public void StartMovingForward(bool opposite)
    {
        startMoving = true;
        direction = (!opposite) ? cameraObj.forward : -cameraObj.forward;
        direction *= speed;
        side = (!opposite) ? 1 : 2;
    }
    public void StartMovingSides(bool opposite)
    {
        startMoving = true;
        direction = (!opposite) ? cameraObj.right : -cameraObj.right;
        direction *= speed;
        side = (!opposite) ? 3 : 4;
    }
    public void StopMoving()
    {
        startMoving = false;
    }
}
