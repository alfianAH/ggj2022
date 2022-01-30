using Box;
using Gameplay;

namespace UserInterfaces
{
    public class ButtonManager : SingletonBaseClass<ButtonManager>
    {
        private BoxManager boxManager;
        private BoxSpawnerManager boxSpawnerManager;
        private GameplayManager gameplayManager;
        private HealthManager healthManager;
        private ScoreManager scoreManager;

        private int combo;

        private void Awake() {
            boxManager = BoxManager.Instance;
            boxSpawnerManager = BoxSpawnerManager.Instance;
            gameplayManager = GameplayManager.Instance;
            healthManager = HealthManager.Instance;
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
                scoreManager.UpdateScore(scoreManager.ScoreValue + 2*combo);
                UltimateBox.Instance.AddPower(combo);
                // Destroy cube
                boxManager.RemoveBox();
            } else {
                // Reduce heart by 1
                combo = 0;
                healthManager.ReduceHealth();
            }
        }

        public void StartUltimate(){
            StartCoroutine(UltimateBox.Instance.StartUltimate());
        }
    }
}