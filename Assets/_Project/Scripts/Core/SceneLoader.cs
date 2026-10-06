using UnityEngine;
using UnityEngine.SceneManagement;
namespace MemoAndCo.Core
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

        public const string MainMenuScene = "MainMenu";
        public const string GameplayScene = "Gameplay";
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(MainMenuScene);
        }
        public void LoadGameplay()
        {
            SceneManager.LoadScene(GameplayScene);
        }
        public void LoadScene(string sceneName) {
            if (SceneUtility.GetBuildIndexByScenePath(sceneName) == -1) 
            {
                Debug.LogError($"Scene {sceneName} dont add to Build Settings");
                return;
            }
            SceneManager.LoadScene(sceneName);
        }
    }
}
