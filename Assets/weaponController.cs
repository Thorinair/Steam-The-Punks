using UnityEngine;
using System.Collections;

public class weaponController : MonoBehaviour {

    Vector2 mouseAim;
    Vector2 smoothV;

    public float sensitivity = 0.1f;
    public float smoothing = 1f;
    public float damage = 5f;
    public float radius = 0f;

    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);

        mouseAim += smoothV;

        this.transform.localRotation = Quaternion.AngleAxis(Mathf.Clamp(mouseAim.x,-20,25), this.transform.up);

        if (Input.GetMouseButton(0))
        {
            Fire();
        }
	}

    void Fire()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "Enemy")
            {

            }
        }
    }
}
