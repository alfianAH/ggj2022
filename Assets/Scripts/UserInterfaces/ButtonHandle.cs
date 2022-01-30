using SceneLoading;
using UnityEngine;

namespace UserInterface{
    public class ButtonHandle : MonoBehaviour {
        public void LoadScene(string sceneName){
            SceneLoadTrigger.Instance.LoadScene(sceneName);
        }
    }
}