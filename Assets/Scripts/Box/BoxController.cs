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

        public void SetPosition(Vector2 position){
            transform.position = position;
        }

        public void SetBoxSprite(Sprite sprite){
            boxSpriteRenderer.sprite = sprite;
        }
    }
}