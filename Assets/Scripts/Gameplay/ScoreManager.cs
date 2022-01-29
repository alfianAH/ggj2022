using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class ScoreManager : SingletonBaseClass<ScoreManager>
    {
        public Text scoreText;

        private int score = 0;

        public int ScoreValue
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                scoreText.text = score.ToString();
            }
        }
    }
}