using Game.Player.Abstract.Input;
using Game.Player.Abstract.Movement;
using Game.Player.Concreates.Input;
using Game.Player.Concreates.Movement;
using Game.Player.Visual;
using UnityEngine;

namespace Game.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        #region Singleton
        private static PlayerController instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }

        public static PlayerController GetInstance()
        {
            return instance;
        }

        #endregion

        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float flyForce;
        [SerializeField] private Rigidbody2D rb;

        public GameMode gameMode;

        private IPlayerMovement playerMovement;
        private IPlayerInput playerInput;

        private void Start()
        {
            gameMode = GameMode.Jump;
            playerMovement = new MoveWithRigidbody(speed, jumpForce, flyForce, rb);
            playerInput = new PlayerInput();
        }

        private void Update()
        {
            playerMovement.Move();

            if (gameMode == GameMode.Jump)
            {
                if (playerInput.Jump)
                {
                    playerMovement.Jump();
                }
            }
            else
            {
                if (playerInput.Holding)
                {
                    playerMovement.Fly();
                }
            }

            if(!playerMovement.IsGrounded())
            {
                switch (gameMode)
                {
                    case GameMode.Jump:
                        PlayerVisual.GetInstance().StopYellowRunningParticles();
                        break;
                    case GameMode.Fly:
                        PlayerVisual.GetInstance().StopGreenRunningParticles();
                        PlayerVisual.GetInstance().PlayFlyingParticles();
                        break;
                }   
            }
            else
            {
                switch (gameMode)
                {
                    case GameMode.Jump:
                        PlayerVisual.GetInstance().PlayYellowRunningParticles();
                        break;
                    case GameMode.Fly:
                        PlayerVisual.GetInstance().PlayGreenRunningParticles();
                        PlayerVisual.GetInstance().StopFlyingParticles();
                        break;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(rb.transform.GetChild(0).position, Vector3.down * 0.1f);
        }
    }
}
