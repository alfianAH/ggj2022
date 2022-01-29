using Box;
using Gameplay;
using UnityEngine;

namespace UserInterfaces
{
    public class ButtonManager : SingletonBaseClass<ButtonManager>
    {
        private BoxSpawnerManager boxSpawnerManager;
        private GameplayManager gameplayManager;
        private ScoreManager scoreManager;

        private int combo;

        private void Awake() {
            boxSpawnerManager = BoxSpawnerManager.Instance;
            gameplayManager = GameplayManager.Instance;
            scoreManager = ScoreManager.Instance;
        }
        
        /// <summary>
        /// Check cube if button is pressed
        /// </summary>
        public void CheckCube(){
            BoxPersonality targetPersonality = boxSpawnerManager.BoxQueue.Peek().BoxProperties.boxPersonality;
            BoxPersonality chosenPersonality = gameplayManager.chosenBoxPersonality;

            if(targetPersonality == chosenPersonality){
                // Add score
                combo += 1;
                scoreManager.ScoreValue *= combo;

                // Destroy cube

            } else {
                // Reduce heart by 1
                combo = 0;
            }
        }
    }
}