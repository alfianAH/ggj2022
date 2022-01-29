using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Box
{
    public class BoxBarMeter : MonoBehaviour
    {
        public BoxController boxController;
        [SerializeField] private float speed = 0.2f;
        private RectTransform parent, rectTransform;
        private Canvas canvas;
        private Camera mainCamera;
        private bool goingUp;
        private ScoreManager scoreManager;
        private Slider barSlider;
        
        private void Awake() {
            scoreManager = ScoreManager.Instance;

            canvas = GetComponentInParent<Canvas>();
            mainCamera = Camera.main;
            rectTransform = GetComponent<RectTransform>();
            parent = GetComponentInParent<RectTransform>();
            barSlider = GetComponent<Slider>();
        }

        private void OnEnable() {
            barSlider.value = boxController.BoxProperties.boxPersonality == BoxPersonality.Negative
                ? 0f : 1f;
            goingUp = true;
        }

        private void Update() {
            if(barSlider.value <= 0f){
                boxController.ChangePersonality(BoxPersonality.Negative);
                goingUp = true;
            } else if (barSlider.value >= 1f){
                boxController.ChangePersonality(BoxPersonality.Positive);
                goingUp = false;
            }

            if(goingUp){
                barSlider.value += speed * Time.deltaTime;
            } else{
                barSlider.value -= speed * Time.deltaTime;
            }

            HandlePosition(boxController.transform.position);

            CheckPoint();
        }

        /// <summary>
        /// Handle interaction button position
        /// Convert world space position to canvas position 
        /// </summary>
        /// <param name="targetPosition">World space position</param>
        private void HandlePosition(Vector3 targetPosition)
        {
            Vector2 actorScreenPosition = mainCamera.WorldToScreenPoint(targetPosition);
            // Make it to the right a bit, so it doesn't cover the actor
            actorScreenPosition.x += 50;
            
            // Set anchored position for interaction button
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parent, actorScreenPosition,
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCamera,
                out var anchoredPosition);

            rectTransform.anchoredPosition = anchoredPosition;
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