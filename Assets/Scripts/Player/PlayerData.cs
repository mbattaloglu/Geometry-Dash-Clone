using UnityEngine;

namespace Game.Player.Data
{
    public class PlayerData : MonoBehaviour
    {
        #region Singleton
        private static PlayerData instance;
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

        private PlayerData() { }

        public static PlayerData GetInstance()
        {
            return instance;
        }
        #endregion

        public bool isMenuMusicOn;

        private void Start()
        {
            isMenuMusicOn = PlayerPrefs.GetInt("MenuMusic", 1) == 1;
        }

        public void SaveMenuMusic()
        {
            PlayerPrefs.SetInt("MenuMusic", isMenuMusicOn ? 1 : 0);
        }

        public bool GetMenuMusic()
        {
            return PlayerPrefs.GetInt("MenuMusic", 1) == 1;
        }

        public void SetMenuMusic(bool isOn)
        {
            isMenuMusicOn = isOn;
            SaveMenuMusic();
        }
    }
}
