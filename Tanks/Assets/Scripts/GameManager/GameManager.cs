using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Scripts.Settings;

namespace Scripts.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private PlayerSettings playerSettings; 
        [SerializeField] private Button reStartButton;

        private bool canTick = true;

        private void OnEnable()
        {
            reStartButton.onClick.AddListener(RestartGame);
        }

        private void OnDisable()
        {
            reStartButton.onClick.RemoveAllListeners();
        }

        private void Update()
        {
            Listen();
        }

        private void Listen()
        {
            if (playerSettings.Health <= 0 && canTick)
            {
                canTick = false;
                GameOver();
            }
        }

        private void GameOver()
        {
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
        }

        private void RestartGame()
        {
            SceneManager.UnloadSceneAsync(0);
        }
    }
}