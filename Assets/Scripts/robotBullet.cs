using UnityEngine;
using System.Collections;

public class robotBullet : MonoBehaviour {

    public float damage = 1f;

    void OnTriggerEnter(Collider col){
        if (col.tag == "Enemy")
        {
            GameObject enemy = col.gameObject;
            enemy.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(col.tag=="Building")
        {
            Destroy(gameObject);
        }
    }
}
