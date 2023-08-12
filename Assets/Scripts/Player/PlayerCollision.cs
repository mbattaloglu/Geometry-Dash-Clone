using System.Collections;
using Game.General.Logic;
using Game.General.UI;
using Game.Player.Animator;
using Game.Player.Controller;
using Game.Player.Visual;
using UnityEngine;

namespace Game.Player.Collision
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                CoreGame.GetInstance().EndGame();
                switch (PlayerController.GetInstance().gameMode)
                {
                    case GameMode.Jump:
                        StartCoroutine(PlayerVisual.GetInstance().PlayYellowDeath());
                        break;
                    case GameMode.Fly:
                        StartCoroutine(PlayerVisual.GetInstance().PlayGreenDeath());
                        break;
                }
                StartCoroutine(CoreGame.GetInstance().RestartGame());
            }
        }

        private IEnumerator OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Portal"))
            {
                GameMode activatedLevel = PlayerController.GetInstance().gameMode;
                PlayerController.GetInstance().gameMode = activatedLevel == GameMode.Jump ? GameMode.Fly : GameMode.Jump;
                PlayerVisual.GetInstance().ChangeSprite(PlayerController.GetInstance().gameMode);
                yield return null;
            }

            if (other.gameObject.CompareTag("Finish"))
            {
                CoreGame.GetInstance().EndGame();
                yield return StartCoroutine(PlayerAnimator.GetInstance().FinishAnimation(other.transform.GetChild(0).position));
                PanelManager.GetInstance().EndGame();
            }
        }
    }
}