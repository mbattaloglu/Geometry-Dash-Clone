using Game.General.Audio;
using Game.Player.Data;
using UnityEngine;

namespace Game.General.UI
{
    public class ButtonManager : MonoBehaviour
    {
        public GameObject audioOnButton;
        public GameObject audioOffButton;

        public GameObject pauseMenu;
        public GameObject pauseButton;

        private void Start()
        {
            ChangeMusicButtonImage(PlayerData.GetInstance().GetMenuMusic());
        }

        public void SetMusicStatus(bool isOn)
        {
            PlayerData.GetInstance().SetMenuMusic(isOn);
            if (isOn)
            {
                AudioManager.GetInstance().PlayMenuTheme();
            }
            else
            {
                AudioManager.GetInstance().StopMenuTheme();
            }

            ChangeMusicButtonImage(isOn);
        }

        private void ChangeMusicButtonImage(bool isOn)
        {
            audioOnButton.SetActive(isOn);
            audioOffButton.SetActive(!isOn);
        }

        public void PauseGame()
        {
            pauseButton.SetActive(false);
        }

        public void ResumeGame()
        {
            pauseButton.SetActive(true);
        }
    }
}
