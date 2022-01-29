using UnityEngine;

namespace Box
{
    public class BoxController : MonoBehaviour
    {
        [SerializeField] private BoxProperties boxProperties;
        private SpriteRenderer boxSpriteRenderer;

        #region Setter and Getter

        public BoxProperties BoxProperties => boxProperties;
        public SpriteRenderer BoxSpriteRenderer => boxSpriteRenderer;

        #endregion

        private void Awake() {
            boxSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Set box random position
        /// </summary>
        /// <param name="position">Box's position</param>
        public void SetPosition(Vector2 position){
            transform.position = position;
        }

        /// <summary>
        /// Change box personality
        /// </summary>
        /// <param name="boxPersonality"></param>
        public void ChangePersonality(BoxPersonality boxPersonality){
            boxProperties.boxPersonality = boxPersonality;
            // Check personality sprite
            foreach(BoxSprite boxSprite in boxProperties.boxSprites){
                if(boxSprite.boxPersonality == boxPersonality){
                    boxSpriteRenderer.sprite = boxSprite.personalitySprite;
                    break;
                }
            }
        }
    }
}