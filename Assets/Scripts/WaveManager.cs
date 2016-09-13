using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

    public int start = 10;
    public int timeout = 60;

    public GameObject e1;
    public GameObject e2;

    int[,] waveCounts;
    GameObject[,] waveEnemies;
    SpawnManager spawnManager_N;
    SpawnManager spawnManager_SR;
    SpawnManager spawnManager_SL;
    SpawnManager spawnManager_WD;
    SpawnManager spawnManager_WU;
    int waveCounter = 0;

    // Use this for initialization
    void Start () {
        spawnManager_N = GameObject.Find("SpawnManager_N").GetComponent<SpawnManager>();
        spawnManager_SR = GameObject.Find("SpawnManager_SR").GetComponent<SpawnManager>();
        spawnManager_SL = GameObject.Find("SpawnManager_SL").GetComponent<SpawnManager>();
        spawnManager_WD = GameObject.Find("SpawnManager_WD").GetComponent<SpawnManager>();
        spawnManager_WU = GameObject.Find("SpawnManager_WU").GetComponent<SpawnManager>();

        waveCounts = new int[,] {
            { 0, 0, 0, 2, 0 },
            { 0, 0, 0, 0, 2 },
            { 2, 0, 2, 0, 0 },
            { 0, 0, 0, 4, 0 },
            { 2, 2, 0, 4, 0 },
            { 2, 2, 0, 4, 4 },
            { 2, 2, 2, 2, 2 }
        };

        waveEnemies = new GameObject[,] {
            { null, null, null, e1,   null },
            { null, null, null, null, e1   },
            { e1,   null, e1,   null, null },
            { null, null, null, e2,   null },
            { e1,   e1,   null, e2,   null },
            { e1,   e1,   null, e2,   e2   },
            { e1,   e1,   e1,   e1,   e1   }
        };

        Invoke("NextWave", start);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void NextWave() {
        if (waveEnemies[waveCounter,0] != null)
            spawnManager_N.SpawnWave(waveEnemies[waveCounter, 0], waveCounts[waveCounter, 0]);
        if (waveEnemies[waveCounter, 1] != null)
            spawnManager_SR.SpawnWave(waveEnemies[waveCounter, 1], waveCounts[waveCounter, 1]);
        if (waveEnemies[waveCounter, 2] != null)
            spawnManager_SL.SpawnWave(waveEnemies[waveCounter, 2], waveCounts[waveCounter, 2]);
        if (waveEnemies[waveCounter, 3] != null)
            spawnManager_WD.SpawnWave(waveEnemies[waveCounter, 3], waveCounts[waveCounter, 3]);
        if (waveEnemies[waveCounter, 4] != null)
            spawnManager_WU.SpawnWave(waveEnemies[waveCounter, 4], waveCounts[waveCounter, 4]);

        Debug.Log("Wave " + waveCounter + " spawned!");

        waveCounter++;
        if (waveCounter < waveCounts.Length)
            Invoke("NextWave", timeout);
    }
}
