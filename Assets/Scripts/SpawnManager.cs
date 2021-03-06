﻿using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    float spawnCooldown = 1f;
    float spawnCooldownRemaining = 0;
    public int spawnIndex = 0;

    [System.Serializable]

    public class WaveComponent {
        public GameObject enemyPrefab;
        public int num;
        [System.NonSerialized]
        public int spawned = 0;

    }
    public WaveComponent wc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bool didSpawn = false;
        if (wc != null) {
            spawnCooldownRemaining -= Time.deltaTime;
            if (spawnCooldownRemaining < 0) {
                spawnCooldownRemaining = spawnCooldown;
                
                if (wc.spawned < wc.num) {
                    wc.spawned++;
                    GameObject instance = (GameObject)Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);
                    instance.GetComponent<Enemy>().SetWaypoint(GameObject.Find("Path"), spawnIndex);
                    didSpawn = true;
                }

                if (didSpawn == false) {
                    //Spawn next wave
                    if (transform.parent.childCount > 1) {
                        transform.parent.GetChild(1).gameObject.SetActive(true);
                    }
                    else {
                        //Last wave
                    }
                }
            }
        }
	}

    public void SpawnWave(GameObject enemy, int number) {
        wc.enemyPrefab = enemy;
        wc.num = number;
        wc.spawned = 0;
    }
}
