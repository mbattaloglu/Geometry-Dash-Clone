using Game.Player.Controller;
using UnityEngine;
using Game.Ground.Scroll;
using System.Collections;
using Game.Player.Visual;
using Game.Player.Animator;
using Game.Object.Abstract.Controller;

namespace Game.General.Logic
{
    public class CoreGame : MonoBehaviour
    {
        #region Singleton
        private static CoreGame instance;
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

        private CoreGame() { }

        public static CoreGame GetInstance()
        {
            return instance;
        }
        #endregion

        [SerializeField]
        private Transform startingPoint;
        [SerializeField]
        private Transform spawnedObjects;

        [SerializeField]
        private GameObject player;
        [SerializeField]
        private GameObject spawner;
        [SerializeField]
        private GameObject ground;
        [SerializeField]
        private GameObject background;

        private void Start()
        {
            EndGame();
            StartCoroutine(StartAnimation());
        }

        public void StartGame()
        {
            DestroyObstacles();

            ResetPlayer();

            spawner.SetActive(true);
            ground.GetComponent<GroundScroller>().enabled = true;
            background.GetComponent<GroundScroller>().enabled = true;
        }

        public void EndGame()
        {
            StopObstacles();

            FreezePlayer();

            spawner.SetActive(false);
            ground.GetComponent<GroundScroller>().enabled = false;
            background.GetComponent<GroundScroller>().enabled = false;
        }

        private IEnumerator StartAnimation()
        {
            yield return StartCoroutine(PlayerAnimator.GetInstance().MovementAnimation(startingPoint.position));

            StartGame();
        }

        public IEnumerator RestartGame()
        {
            yield return new WaitForSeconds(1.25f);
            player.transform.position = startingPoint.position;
            StartGame();
        }

        public void DestroyObstacles()
        {
            foreach (Transform obstacle in spawnedObjects)
            {
                Destroy(obstacle.gameObject);
            }
        }

        public void StopObstacles()
        {
            foreach (Transform obstacle in spawnedObjects)
            {
                obstacle.GetComponent<IObjectController>().Stop();
            }
        }

        public void FreezePlayer()
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<PlayerVisual>().enabled = false;
        }

        public void ResetPlayer()
        {

            player.GetComponent<Rigidbody2D>().isKinematic = false;
            player.GetComponent<Rigidbody2D>().simulated = true;
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<PlayerVisual>().enabled = true;
            PlayerController.GetInstance().gameMode = GameMode.Jump;
            PlayerVisual.GetInstance().ResetSprite();
        }
    }
}