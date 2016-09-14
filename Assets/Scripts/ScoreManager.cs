using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int lives = 20;
    public int money = 10000;
    public Text moneyText;
    public Text livesText;

    void Update()
    {
        moneyText.text = "Money: " + money.ToString();
        livesText.text = "Lives left: " + lives.ToString();
    }

    public void LoseLife(int l=1)
    {
        lives -=l;
        if (lives <= 0)
        {
            GameOver();
        }
    }
    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
