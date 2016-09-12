using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    private LineRenderer lr;
    private perspectiveChanger perspective;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        perspective = GameObject.Find("Level").GetComponent<perspectiveChanger>();
	}
	
	// Update is called once per frame
	void Update () {
        if (perspective.FPS == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider)
                {
                    lr.SetPosition(1, new Vector3(0, 0, hit.distance));
                }
            }
            else
            {
                lr.SetPosition(1, new Vector3(0, 0, 50));
            }
        }

	}
}
