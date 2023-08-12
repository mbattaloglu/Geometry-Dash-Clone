using Game.Object.Abstract.Movement;
using UnityEngine;

namespace Game.Object.Concreate.Movement
{
    public class PortalMovement : IObjectMovement
    {
        private float speed;
        private Transform transform;

        private Vector3 direction;

        public PortalMovement(Transform transform, float speed)
        {
            this.transform = transform;
            this.speed = speed;

            direction = Vector3.left * speed;
        }

        public void Move()
        {
            transform.position += direction * Time.deltaTime;
        }

        public void Stop()
        {
            direction = Vector3.zero;
        } 
    }
}
