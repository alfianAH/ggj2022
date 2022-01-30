﻿using Effects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneLoading
{
    public class SceneLoadTrigger : SingletonBaseClass<SceneLoadTrigger>
    {
        #region Don't Destroy On Load

        /// <summary>
        /// Use only 1 Scene Load Trigger from HomeScene
        /// </summary>
        private void SetInstance()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        #endregion
        
        private const string LOADING_SCENE_NAME = "LoadingScene";

        private void Awake()
        {
            SetInstance();
        }
        /// <summary>
        /// Load loading scene to trigger scene loader by name
        /// </summary>
        /// <param name="sceneName">Scene's name to load</param>
        public void LoadScene(string sceneName)
        {

            LoadingData.sceneName = sceneName;
            SceneManager.LoadScene(LOADING_SCENE_NAME);
        }
    }
}