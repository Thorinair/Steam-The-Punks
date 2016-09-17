using UnityEngine;
using System.Collections;

public class weaponController : MonoBehaviour {

    Vector2 mouseAim;
    Vector2 smoothV;

    public float sensitivity = 0.1f;
    public float smoothing = 1f;
    public float fireCooldown = 0.5f;
    private float cooldownRemaining = 0f;
    public float damage = 100f;
    public float cost = 2500f;
    public string description = "";
    public string robotName = "";
    public float bulletSpeed = 5f;

    public GameObject bulletPrefab;
    private GameObject gun;
    private perspectiveChanger perspective;
	// Use this for initialization
	void Start () {
        gun = GameObject.Find("LaserSight");
        perspective = GameObject.Find("Level").GetComponent<perspectiveChanger>();
	}
	
	// Update is called once per frame
	void Update () {

        if (perspective.FPS == true)
        {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);

            mouseAim += smoothV;

            this.transform.localRotation = Quaternion.AngleAxis(Mathf.Clamp(mouseAim.x, -20, 25), this.transform.up);

            cooldownRemaining -= Time.deltaTime;

            if (Input.GetMouseButton(0) && cooldownRemaining <= 0)
            {
                Fire();
                cooldownRemaining = fireCooldown;
            }
        }

	}

    void Fire()
    {
        Vector3 startPosition = gun.transform.position;
        GameObject bullet = Instantiate(bulletPrefab, startPosition,gun.transform.rotation) as GameObject;

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, 2.0f);
    }
}
