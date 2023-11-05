
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets
{
    public class ListSceneManager : MonoBehaviour
    {
        private ListSceneManager() { }
        private static ListSceneManager instance;
        public static ListSceneManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ListSceneManager();
                }

                return instance;
            }
        }

        List<string> listScenes = new List<string>()
        {
             { "MainMenu"},
             { "Village Backside" },
             { "AstalVillage"}
        };

        public string GetCurrentScene()
        {
            return SceneManager.GetActiveScene().name;
        }

        public void LoadPreviousScene()
        {
            int previousSceneIndex = listScenes.IndexOf(GetCurrentScene()) - 1;

            string previousSceneName = listScenes[previousSceneIndex];
            
            SceneManager.LoadSceneAsync(previousSceneName);
        }

        public void LoadNextScene()
        {
            int nextSceneIndex = listScenes.IndexOf(GetCurrentScene()) + 1;
            string nextSceneName = listScenes[nextSceneIndex];
            SceneManager.LoadSceneAsync(nextSceneName);
        }
    }
}
