using UnityEngine;

namespace MemoAndCo.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public GameState CurrentState { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        private void Start()
        {
            ChangeState(GameState.Bootstrap);
            if (SceneLoader.Instance == null)
            {
                Debug.LogError("SceneLoader не найден. —цена запущена напр€мую, а не через Bootstrap.");
                return;
            }
            GoToMainMenu();
        }
        public void GoToMainMenu()
        {
            ChangeState(GameState.MainMenu);
            SceneLoader.Instance.LoadMainMenu();
        }
        public void GoToGamePlay()
        {
            ChangeState(GameState.Gameplay);
            SceneLoader.Instance.LoadGameplay();
        }
        private void ChangeState(GameState newState)
        {
            if (CurrentState == newState) return;
            GameState oldState = CurrentState;
            CurrentState = newState;
            Debug.Log($"{oldState} -> {newState}");
        }
    }
}
