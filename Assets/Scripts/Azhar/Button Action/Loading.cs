using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Text EffectLoad;

    private bool loadScene;
    private string tempText;

    private const float WAIT_SECONDS = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        tempText = EffectLoad.text;
        LoadingData.sceneName = "Scene 2";
        StartCoroutine(LoadSceneAsync());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        loadScene = loadingScene.isDone;
        EffectLoad.text = "...";
        Debug.Log("done");
    }
}

public static class LoadingData
{
    public static string sceneName;
}
