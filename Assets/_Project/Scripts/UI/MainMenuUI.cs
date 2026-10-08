using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MemoAndCo.Core;

namespace MemoAndCo.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        private void Start()
        {
            if (startButton == null)
            {
                Debug.LogError("Button is null");
                return;
            }
            startButton.onClick.AddListener(OnStartClicked);
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveListener(OnStartClicked);
        }

        private void OnStartClicked()
        {
            if (SceneLoader.Instance == null)
            {
                Debug.LogError("SceneLoader.Instance is null");
                return;
            }
            GameManager.Instance.GoToGamePlay();
            
        }
    }
}
