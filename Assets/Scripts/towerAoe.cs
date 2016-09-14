using UnityEngine;
using System.Collections;

public class towerAoe : MonoBehaviour {

    float range = 4f;
    public GameObject bulletPrefab;

    float fireCooldown = 0.5f;
    float fireCooldownLeft = 0;

    public float damage = 1f;
    public float radius = 0;

    int acc = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
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
            //Pripazi na modeliranje
            Vector3 dir = nearestEnemy.transform.position - this.transform.position;

            fireCooldownLeft -= Time.deltaTime;

            if (fireCooldownLeft <= 0 && dir.magnitude <= range) {
                fireCooldownLeft = fireCooldown;
                ShootAt(nearestEnemy);
            }
        }
    }

    void ShootAt(Enemy e)
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        Bullet b = bulletGO.GetComponent<Bullet>();
        b.target = e.transform;
        b.damage = damage;
        b.radius = radius;
    }
}
