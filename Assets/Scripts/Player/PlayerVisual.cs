using System.Collections;
using Game.Player.Animator;
using UnityEngine;

namespace Game.Player.Visual
{
    public class PlayerVisual : MonoBehaviour
    {
        #region Singleton
        private static PlayerVisual instance;

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

        private PlayerVisual() { }

        public static PlayerVisual GetInstance()
        {
            return instance;
        }
        #endregion

        [SerializeField] private Sprite jumpSprite;
        [SerializeField] private Sprite flySprite;

        [SerializeField] private ParticleSystem yellowRunningParticles;
        [SerializeField] private ParticleSystem greenRunningParticles;
        [SerializeField] private ParticleSystem flyingParticles;
        [SerializeField] private ParticleSystem yellowDeathParticles;
        [SerializeField] private ParticleSystem greenDeathParticles;

        private ParticleSystem activeParticle;

        private Vector3 initialScale;

        private void Start()
        {
            initialScale = transform.localScale;
        }

        private void OnEnable()
        {
            activeParticle = yellowRunningParticles;

            yellowRunningParticles.gameObject.SetActive(true);
            greenRunningParticles.gameObject.SetActive(false);
            flyingParticles.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            yellowRunningParticles.gameObject.SetActive(false);
            greenRunningParticles.gameObject.SetActive(false);
            flyingParticles.gameObject.SetActive(false);
        }

        public void ChangeSprite(GameMode gameMode)
        {
            StartCoroutine(ChangeSpriteAnimation(gameMode));
        }

        private IEnumerator ChangeSpriteAnimation(GameMode gameMode)
        {
            activeParticle.gameObject.SetActive(false);

            yield return StartCoroutine(PlayerAnimator.GetInstance().CloseScale());

            switch (gameMode)
            {
                case GameMode.Jump:
                    GetComponent<SpriteRenderer>().sprite = jumpSprite;
                    break;
                case GameMode.Fly:
                    GetComponent<SpriteRenderer>().sprite = flySprite;
                    break;
            }

            yield return StartCoroutine(PlayerAnimator.GetInstance().OpenScale(initialScale));

            switch (gameMode)
            {
                case GameMode.Jump:
                    PlayYellowRunningParticles();
                    break;
                case GameMode.Fly:
                    PlayGreenRunningParticles();
                    break;
            }
        }

        public void ResetSprite()
        {
            GetComponent<SpriteRenderer>().sprite = jumpSprite;
        }

        public void PlayYellowRunningParticles()
        {
            yellowRunningParticles.gameObject.SetActive(true);
            activeParticle = yellowRunningParticles;
        }

        public void StopYellowRunningParticles()
        {
            yellowRunningParticles.gameObject.SetActive(false);
        }

        public void PlayGreenRunningParticles()
        {
            greenRunningParticles.gameObject.SetActive(true);
            activeParticle = greenRunningParticles;
        }

        public void StopGreenRunningParticles()
        {
            greenRunningParticles.gameObject.SetActive(false);
        }

        public void PlayFlyingParticles()
        {
            flyingParticles.gameObject.SetActive(true);
            activeParticle = flyingParticles;
        }

        public void StopFlyingParticles()
        {
            flyingParticles.gameObject.SetActive(false);
        }

        public IEnumerator PlayYellowDeath()
        {
            yellowDeathParticles.gameObject.SetActive(true);
            while (yellowDeathParticles.isPlaying)
            {
                yield return null;
            }
            yellowDeathParticles.gameObject.SetActive(false);
        }

        public IEnumerator PlayGreenDeath()
        {
            greenDeathParticles.gameObject.SetActive(true);
            while (greenDeathParticles.isPlaying)
            {
                yield return null;
            }
            greenDeathParticles.gameObject.SetActive(false);
        }

        public void PlayYellowDeathParticles()
        {
            yellowDeathParticles.gameObject.SetActive(true);
        }

        public void PlayGreenDeathParticles()
        {
            greenDeathParticles.gameObject.SetActive(true);
        }
    }
}
