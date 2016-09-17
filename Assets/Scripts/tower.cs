using UnityEngine;
using System.Collections;

public class tower : MonoBehaviour {

    Transform turretTransform;
    Transform barrelTransform;

    public float range = 10f;
    public float damage = 1f;
    public float radius = 0f;
    public string towerName = "";
    public string description = "";
    public GameObject bulletPrefab;

    int acc = 1;
    public int cost = 100;

    public float fireCooldown = 0.5f;
    float fireCooldownLeft = 0;

    public bool isFire = false;

    Enemy[] enemies;

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
        acc++;

        if (acc >= 60) {
            acc = 1;
            enemies = FindObjectsOfType<Enemy>();
        }

        if (enemies != null) {
            Enemy nearestEnemy = null;
            float dist = range;

            foreach (Enemy e in enemies) {
                if (e != null) {
                    float d = Vector3.Distance(this.transform.position, e.transform.position);
                    if (nearestEnemy == null || d < dist) {
                        nearestEnemy = e;
                        dist = d;
                    }
                }
                else {
                    return;
                }
            }
            if (nearestEnemy == null) {
                // Debug.Log("No enemies!");
                return;
            }

            if (dist <= range) {
                Vector3 dir = nearestEnemy.transform.position - this.transform.position;

                Quaternion.Angle(this.transform.rotation, nearestEnemy.transform.rotation);

                if (turretTransform != null) {
                    Quaternion lookRot = Quaternion.LookRotation(dir);
                    turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);
                }


                fireCooldownLeft -= Time.deltaTime;

                
                if (fireCooldownLeft <= 0 && dir.magnitude <= range) {
                    fireCooldownLeft = fireCooldown;
                    ShootAt(nearestEnemy);
                }
            }
        }
    }

    void ShootAt(Enemy e) {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, barrelTransform.transform.position, barrelTransform.transform.rotation);

        if (isFire) {
            e.GetComponent<Enemy>().TakeDamage(damage);
        }
        else {
            Bullet b = bulletGO.GetComponent<Bullet>();
            b.target = e.transform;
            b.damage = damage;
            b.radius = radius;
        }
    }
}
