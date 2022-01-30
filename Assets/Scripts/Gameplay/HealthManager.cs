using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class HealthManager : SingletonBaseClass<HealthManager>
    {
        [SerializeField] private Image healthIcon;
        [SerializeField] private Transform panelHealth;
        [SerializeField] private Sprite healthIconFull, healthIconEmpty;
        [SerializeField] private GameObject gameOverObject;

        [SerializeField] private int health = 3;

        private List<Image> healthIcons;

        private void Start()
        {
            healthIcons = new List<Image>();
            AddHealthUI();
        }

        /// <summary>
        /// Add health icon at the start
        /// </summary>
        private void AddHealthUI()
        {
            for (int i = 0; i < health; i++)
            {
                Image newHealth = Instantiate(healthIcon, panelHealth);
                newHealth.sprite = healthIconFull;
                healthIcons.Add(newHealth);
            }
        }

        /// <summary>
        /// Reduce health
        /// </summary>
        public void ReduceHealth(){
            health -= 1;
            foreach(Image healthIcon in healthIcons){
                if (healthIcon.sprite == healthIconFull)
                {
                    healthIcon.sprite = healthIconEmpty;
                    break;
                }
            }

            if(health == 0){
                gameOverObject.SetActive(true);
                ScoreManager.Instance.UpdateHighScore();
            }
        }
    }
}