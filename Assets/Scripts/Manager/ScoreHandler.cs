using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public GameObject playerObj;
    Player player;
    
    // how often the score gets updated while playing
    public float scoreCountTime;
    // how much gets added each time to the score
    public int addAmount;
    
    public GameObject newHighScoreBadge;
    
    int speedLevel;
    public int speedLimit;
    
    public GameObject scoreObj;
    public GameObject highScoreObj;
    public GameObject finalScoreObj;
    public GameObject highScoreEndScreenObj;
    TextMeshPro scoreText;
    TextMeshPro highScoreText;
    TextMeshPro finalScoreText;
    TextMeshPro highScoreEndScreenText;
    
    // score value
    int score;
    int finalScore;
    
    // is the game actively counting / adding score
    bool isCountingScore;
    
    #region Singleton
    public static ScoreHandler instance;
    void Awake(){
        instance = this;
    }
    #endregion
    
    void Start() {
        player = playerObj.transform.GetComponent<Player>();
        
        scoreText = scoreObj.transform.GetComponent<TextMeshPro>();
        highScoreText = highScoreObj.transform.GetComponent<TextMeshPro>();
        finalScoreText = finalScoreObj.transform.GetComponent<TextMeshPro>();
        highScoreEndScreenText = highScoreEndScreenObj.transform.GetComponent<TextMeshPro>();
        
        GameEvents.instance.onPlayerDie += StopScore;
        GameEvents.instance.onRestartLevel += StartCounting;
        
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
    
    void Update(){
        IncreaseSpeed();
    }
    
    public void IncreaseSpeed(){
        if((score / 75) > speedLevel){
            if(player.moveSpeedActual < speedLimit){
                player.moveSpeedActual++;
            }
        }
        speedLevel = score / 75;
    }
    
    // access this function to begin counting score in the game
    public void StartCounting(){
        scoreText.text = "Score: 0";
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        
        isCountingScore = true;
        StartCoroutine(CountScore());
    }
    
    public void AddScore(int amount){
        if(isCountingScore){
            score += amount;
            scoreText.text = "Score: " + score;
        }
    }
    
    IEnumerator CountScore(){
        while(isCountingScore){
            yield return new WaitForSeconds(scoreCountTime);
            AddScore(addAmount);
        }
    }
    
    public void StopScore(){
        HighScoreSet();
        
        scoreText.text = "";
        highScoreText.text = "";
        
        isCountingScore = false;
        finalScore = score;
        finalScoreText.text = "Final Score: " + finalScore;
        
        highScoreEndScreenText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        score = 0;
        
        speedLevel = 0;
        player.moveSpeedActual = 19;
    }
    
    public void HighScoreSet(){
        if(score > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }
}
