using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class ScoreManager : SingletonBaseClass<ScoreManager>
    {
        [SerializeField] private Text scoreText, finishScoreText, highScoreText;

        private int score = 0;

        private const string HIGH_SCORE_KEY = "HighScore";

        public int ScoreValue => score;

        private void Awake() {
            UpdateScore(0);
        }

        public void UpdateScore(int value){
            score = value;
            scoreText.text = score.ToString();
            finishScoreText.text = "Your Score\n" + score.ToString();
        }

        public void UpdateHighScore(){
            if(PlayerPrefs.HasKey(HIGH_SCORE_KEY)){
                // Check high score
                if(score > PlayerPrefs.GetInt(HIGH_SCORE_KEY)){
                    PlayerPrefs.SetInt(HIGH_SCORE_KEY, score);
                    highScoreText.text = "Your High Score\n" + score.ToString();
                } else{
                    int highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
                    highScoreText.text = "Your High Score\n" + highScore.ToString();
                }
            } else{
                // Set high score
                PlayerPrefs.SetInt(HIGH_SCORE_KEY, score);
                highScoreText.text = "Your High Score\n" + score.ToString();
            }
        }
    }
}