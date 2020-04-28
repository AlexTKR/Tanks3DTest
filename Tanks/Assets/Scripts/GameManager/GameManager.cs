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

        private bool canTick = true;

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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        private void GameOver()
        {
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
        }
    }
}