using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    float spawnCooldown = 1f;
    float spawnCooldownRemaining = 0;
    public int spawnIndex = 0;

    [System.Serializable]

    public class WaveComponent{
    public GameObject enemyPrefab;
    public int num;
    [System.NonSerialized]
    public int spawned = 0;

    }
    public WaveComponent[] waveComps;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bool didSpawn = false;
        spawnCooldownRemaining -= Time.deltaTime;
        if (spawnCooldownRemaining < 0)
        {
            spawnCooldownRemaining = spawnCooldown;

            foreach (WaveComponent wc in waveComps)
            {
                if (wc.spawned < wc.num)
                {
                    wc.spawned++;
                    GameObject enemy=Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation) as GameObject;
                    enemy.GetComponent<Enemy>().SetWaypoint(spawnIndex);
                    didSpawn = true;
                    break;
                }
            }
            if (didSpawn == false)
            {
                //Spawn next wave
                if (transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    //Last wave
                }

                Destroy(gameObject);
            }
        }
	}
}
