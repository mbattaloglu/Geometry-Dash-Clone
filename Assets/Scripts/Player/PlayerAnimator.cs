using System.Collections;
using UnityEngine;

namespace Game.Player.Animator
{
    public class PlayerAnimator : MonoBehaviour
    {
        #region Singleton

        private static PlayerAnimator instance;

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

        private PlayerAnimator() { }

        public static PlayerAnimator GetInstance()
        {
            return instance;
        }

        #endregion

        public IEnumerator MovementAnimation(Vector3 to)
        {
            while (Vector3.Distance(to, transform.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, to, Time.deltaTime * 13f);
                yield return null;
            }
            transform.position = to;
        }

        public IEnumerator CloseScale()
        {
            while (Vector3.Magnitude(transform.localScale) > 0.1f)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 10);
                yield return null;
            }
            transform.localScale = Vector3.zero;
        }

        public IEnumerator OpenScale(Vector3 initialScale)
        {
            while (Vector3.Magnitude(transform.localScale) < Vector3.Magnitude(initialScale) * 0.95)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, initialScale, Time.deltaTime * 10);
                yield return null;
            }
            transform.localScale = initialScale;
        }

        public IEnumerator FinishAnimation(Vector3 to)
        {
            yield return StartCoroutine(MovementAnimation(to));
            yield return StartCoroutine(CloseScale());
        }
    }
}
