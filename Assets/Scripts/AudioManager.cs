using Game.Player.Data;
using UnityEngine;

namespace Game.General.Audio
{
    public class AudioManager : MonoBehaviour
    {
        #region Singleton
        private static AudioManager instance;

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

        private AudioManager() { }

        public static AudioManager GetInstance()
        {
            return instance;
        }
        #endregion

        public AudioSource menuThemeAudio;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            if (PlayerData.GetInstance().GetMenuMusic())
            {
                PlayMenuTheme();
            }
        }

        public void PlayMenuTheme()
        {
            menuThemeAudio.Play();
        }

        public void StopMenuTheme()
        {
            menuThemeAudio.Stop();
        }
    }
}
