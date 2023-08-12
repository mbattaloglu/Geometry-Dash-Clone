using UnityEngine;

namespace Game.General.UI
{
    public class PanelManager : MonoBehaviour
    {
        #region Singleton
        private static PanelManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private PanelManager() { }

        public static PanelManager GetInstance()
        {
            return instance;
        }
        #endregion

        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject finishPanel;

        private void Start()
        {
            pausePanel.SetActive(false);
            finishPanel.SetActive(false);
        }

        public void PauseGame()
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void EndGame()
        {
            finishPanel.SetActive(true);
        }
    }
}
