using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Box
{
    public class BoxBarMeter : MonoBehaviour
    {
        public BoxController boxController;
        [SerializeField] private float speed = 0.2f;
        private bool goingUp;
        private ScoreManager scoreManager;
        private Slider barSlider;
        
        private void Awake() {
            scoreManager = ScoreManager.Instance;
            barSlider = GetComponent<Slider>();
        }

        private void OnEnable() {
            barSlider.value = boxController.BoxProperties.boxPersonality == BoxPersonality.Negative
                ? 0f : 1f;
            goingUp = true;
        }

        private void Update() {
            // If slide value is 0, change to mad
            if(barSlider.value <= 0f){
                boxController.ChangePersonality(BoxPersonality.Negative);
                goingUp = true;
            } else if (barSlider.value >= 1f){ // If slide value is 1, change to happy
                boxController.ChangePersonality(BoxPersonality.Positive);
                goingUp = false;
            }

            if(goingUp){
                barSlider.value += speed * Time.deltaTime;
            } else{
                barSlider.value -= speed * Time.deltaTime;
            }

            CheckPoint();
        }
        
        /// <summary>
        /// Check point for score manager
        /// </summary>
        private void CheckPoint(){
            if(scoreManager.ScoreValue >= 500){
                speed = 2f;
            } else if(scoreManager.ScoreValue >= 300){
                speed = 1f;
            } else if(scoreManager.ScoreValue >= 200){
                speed = 0.8f;
            } else if(scoreManager.ScoreValue >= 100){
                speed = 0.5f;
            }
        }
    }
}