using UnityEngine;

namespace Box
{
    public class BoxController : MonoBehaviour
    {
        [SerializeField] private BoxProperties boxProperties;
        [SerializeField] private SpriteRenderer boxSpriteRenderer;

        #region Setter and Getter

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
        /// Set box sprite according to box personality
        /// </summary>
        /// <param name="sprite"></param>
        public void SetBoxSprite(Sprite sprite){
            boxSpriteRenderer.sprite = sprite;
        }
    }
}