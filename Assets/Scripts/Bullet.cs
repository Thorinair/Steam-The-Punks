﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 15f;
    public Transform target;
    public float damage = 1f;
    public float radius = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distThisFrame)
        {
            Hit();
        }
        else
        {
            //move to node
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation=Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime);
        }
	}
    void Hit(){
        if (radius == 0)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
        }
        else
        {
            Collider[] cols=Physics.OverlapSphere(transform.position, radius);
            foreach (Collider c in cols)
            {
                Enemy e = c.GetComponent<Enemy>();
                if (e != null)
                {
                    e.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
