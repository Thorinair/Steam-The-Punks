using UnityEngine;
using System.Collections;

public class tower : MonoBehaviour {

    Transform turretTransform;
    Transform barrelTransform;

    public float range = 10f;
    public float damage = 1f;
    public float radius = 0f;
    public string name = "";
    public string description = "";
    public GameObject bulletPrefab;

    int acc = 0;
    public int cost = 100;

    public float fireCooldown = 0.5f;
    float fireCooldownLeft = 0;

	// Use this for initialization
	void Start () {
        turretTransform = transform.Find(gameObject.transform.GetChild(0).name.ToString() + "/turret");
        if (turretTransform != null)
        {
            barrelTransform = turretTransform.Find("barrel");
        }
        
        if (barrelTransform == null)
        {
            barrelTransform = transform.Find(gameObject.transform.GetChild(0).name.ToString() + "/barrel");
        }
	}
	
	// Update is called once per frame
	void Update () {
        acc += 1;

        if (acc >= 3) {
            Tick();
            acc = 0;
        }
    }

    void Tick() {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Enemy nearestEnemy = null;
        float dist = range;

        foreach (Enemy e in enemies) {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if (nearestEnemy == null || d < dist) {
                nearestEnemy = e;
                dist = d;
            }
        }
        if (nearestEnemy == null) {
            // Debug.Log("No enemies!");
            return;
        }

        if (dist <= range) {
            Vector3 dir = nearestEnemy.transform.position - this.transform.position;

            float rot = Quaternion.Angle(this.transform.rotation, nearestEnemy.transform.rotation);

            if (turretTransform != null) {
                Quaternion lookRot = Quaternion.LookRotation(dir);
                turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);
            }


            fireCooldownLeft -= Time.deltaTime;

            if (turretTransform == null) {
                if (rot < 1) {
                    if (fireCooldownLeft <= 0 && dir.magnitude <= range) {
                        fireCooldownLeft = fireCooldown;
                        ShootAt(nearestEnemy);
                    }
                }

            }
            else {
                if (fireCooldownLeft <= 0 && dir.magnitude <= range) {
                    fireCooldownLeft = fireCooldown;
                    ShootAt(nearestEnemy);
                }
            }
        }
    }

    void ShootAt(Enemy e)
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, barrelTransform.transform.position, barrelTransform.transform.rotation);
        Bullet b=bulletGO.GetComponent<Bullet>();
        b.target = e.transform;
        b.damage = damage;
        b.radius = radius;
    }
}
