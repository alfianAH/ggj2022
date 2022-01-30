using System.Collections;
using Effects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneLoading
{
    public class SceneLoader : MonoBehaviour
    {
        [Header("Typing animation")]
        [SerializeField] private Text loadingText;
        [Range(0, 1)]
        [SerializeField] private float typingSpeed = 0.05f;
        private bool stopAnimating;
        private string tempText;
        private const float WAIT_SECONDS = 2.0f;
        
        private void Start()
        {
            tempText = loadingText.text;
            StartCoroutine(TypingAnimation());
            StartCoroutine(LoadSceneAsync());
        }
        
        /// <summary>
        /// Typing animation
        /// </summary>
        /// <returns></returns>
        private IEnumerator TypingAnimation()
        {
            while (!stopAnimating)
            {
                loadingText.text = tempText;

                foreach (char letter in ".....")
                {
                    yield return new WaitForSeconds(typingSpeed);
                    loadingText.text += letter;
                }
            }
        }

        /// <summary>
        /// Load scene asynchronously
        /// </summary>
        /// <returns></returns>
        private IEnumerator LoadSceneAsync()
        {
            // Wait for 3 seconds
            yield return new WaitForSeconds(WAIT_SECONDS);

            // Load scene asynchronously
            AsyncOperation loadingScene = SceneManager.LoadSceneAsync(LoadingData.sceneName);
            stopAnimating = loadingScene.isDone;
        }
    }
}