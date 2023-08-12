using Game.Object.Abstract.Controller;
using Game.Object.Abstract.Movement;
using Game.Object.Concreate.Movement;
using UnityEngine;

namespace Game.Portal.Controller
{
    public class PortalController : MonoBehaviour, IObjectController
    {
        [SerializeField] private float speed = 8f;

        private IObjectMovement movement;

        public void Stop()
        {
            movement.Stop();
        }

        private void Start()
        {
            movement = new PortalMovement(transform, speed);
        }

        private void Update()
        {
            movement.Move();
        }
    }
}