using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    public int start = 10;
    public int timeout = 60;

    public GameObject eEye;
    public GameObject eRob;
    public GameObject eBos;
    public GameObject eEyeE;
    public GameObject eRobE;

    public Text infoText;
    bool informed = false;
    float timeInformed = 0f;

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
           { 0, 0, 0, 2, 0 },//1
           { 0, 0, 0, 0, 2 },//2
           { 0, 0, 2, 0, 0 },//3
           { 0, 0, 4, 0, 4 },//4
           { 0, 6, 0, 4, 0 },//5
           { 4, 4, 1, 4, 4 },//6
           { 4, 4, 4, 4, 4 },//7
           { 6, 6, 6, 6, 6 },//8
           { 10, 10, 8, 10, 10},//9
           { 0, 0, 0, 8, 0 },//10
           { 6, 0, 6, 0, 6},//11
           { 1, 1, 1, 1, 1}, //12
           { 2, 5, 1, 5, 5}
        };

        waveEnemies = new GameObject[,] {
            { null, null, null, eEye, null },//1
            { null, null, null, null, eEye },//2
            { null, null, eEye, null, null },//3
            { null, eEye, null, null, eEye },//4
            { null, eEye, null, eEye, null },//5
            { eEye, eEye, eRob, eEye, eEye },//6
            { eRob, eRob, eRob, eRob, eRob },//7
            { eRob, eRob, eRob, eRob, eRob },//8
            { eEye, eEye, eRob, eEye, eEye },//9
            { null, null, null, eEyeE, null}, //10
            { eEyeE, null, eEyeE, null, eEyeE},//11
            { eRobE, eRobE, eRobE, eRobE, eRobE},//12
            { eRob, eEye, eBos, eRobE, eEyeE}
        };

        Invoke("NextWave", start);
    }
	
	// Update is called once per frame
	void Update () {
        if (informed == true) {
            timeInformed -= Time.deltaTime;
            if (timeInformed <= 0) {
                infoText.text = "";
                informed = false;
            }
        }
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

        infoText.text = "Wave " + (waveCounter+1) + " is approaching!";
        informed = true;
        timeInformed = 2f;

        waveCounter++;
        if (waveCounter < waveCounts.Length)
            Invoke("NextWave", timeout);
    }
}
