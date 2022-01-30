using System.Collections.Generic;
using Box;
using Effects;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class GameplayManager : SingletonBaseClass<GameplayManager>
    {
        public List<BoxSprite> boxSprites;
        public BoxPersonality chosenBoxPersonality;
        [SerializeField] private Button happyButton, madButton;
        [SerializeField] private Image removeButtonSprite;
        [SerializeField] private CanvasGroup choosePanel;

        private void Awake() {
            StartCoroutine(FadingEffect.FadeIn(choosePanel));
            happyButton.onClick.AddListener(() => ChooseBoxPersonality(BoxPersonality.Positive));
            madButton.onClick.AddListener(() => ChooseBoxPersonality(BoxPersonality.Negative));
        }

        private void ChooseBoxPersonality(BoxPersonality boxPersonality){
            chosenBoxPersonality = boxPersonality;
            // Change button sprite
            foreach(BoxSprite boxSprite in boxSprites){
                if(boxSprite.boxPersonality == boxPersonality){
                    removeButtonSprite.sprite = boxSprite.personalitySprite;
                }
            }
            StartCoroutine(FadingEffect.FadeOut(choosePanel));
        }
    }
}