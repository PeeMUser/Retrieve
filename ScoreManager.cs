using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text score;
    //public Text highScore;
    int scoreMon = 0;
    int scoreBoss = 0;
    int scoreMaigc = 0;
    int currentscore = 0;
   
    // Start is called before the first frame update

    private void Awake()
    {

        score.text = PlayerPrefs.GetInt("Score", currentscore).ToString();
        PlayerPrefs.SetInt("Score", currentscore);
        //  highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();

    }
    private void Update()
    {
        
    }


    public void AddPointMonster()
    {
        scoreMon += 20;
        score.text = scoreMon.ToString();
        PlayerPrefs.GetInt("Score", currentscore + 20).ToString();
        score.text = PlayerPrefs.GetInt("Score", currentscore +20).ToString();

        //   PlayerPrefs.SetInt("HighScore", scoreMon);
        //  highScore.text = scoreMon.ToString();


    }
    public void AddPointBoss()
    {
        scoreBoss += 200;
        score.text = scoreBoss.ToString();
        //PlayerPrefs.GetInt("Score", scoreBoss).ToString();
        // if (scoreBoss > PlayerPrefs.GetInt("HighScore", 0))
        //{
        PlayerPrefs.GetInt("Score", currentscore + 200).ToString();
        score.text = PlayerPrefs.GetInt("Score", currentscore + 200).ToString();
        //PlayerPrefs.SetInt("HighScore", scoreBoss);
        //highScore.text = scoreBoss.ToString();
        //}
    }
    public void AddPointMagic()
    {
        scoreMaigc += 50;
        score.text = scoreMaigc.ToString();
        //PlayerPrefs.GetInt("Score", scoreMaigc).ToString();
        // if (scoreMaigc > PlayerPrefs.GetInt("HighScore", 0))
        // {
        PlayerPrefs.GetInt("Score", currentscore + 50).ToString();
        score.text = PlayerPrefs.GetInt("Score", currentscore + 50).ToString();
        //PlayerPrefs.SetInt("HighScore", scoreMaigc);
        // highScore.text = scoreMaigc.ToString();
        //  }
    }
    
}
