using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public int lives = 20;
    public int money = 100;

    public void LoseLife(int l=1)
    {
        lives -= l;
        if (lives <= 0)
        {
            GameOver();
        }
    }
    public void GameOver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
