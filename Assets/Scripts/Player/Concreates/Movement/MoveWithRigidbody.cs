using Game.Player.Abstract.Movement;
using UnityEngine;

namespace Game.Player.Concreates.Movement
{
    public class MoveWithRigidbody : IPlayerMovement
    {
        private float speed;
        private float jumpForce;
        private float flyForce;
        private Rigidbody2D rb;

        private Transform groundCheck;

        public MoveWithRigidbody(float speed, float jumpForce, float flyForce, Rigidbody2D rb)
        {
            this.speed = speed;
            this.jumpForce = jumpForce;
            this.flyForce = flyForce;
            this.rb = rb;

            groundCheck = rb.transform.GetChild(0);
        }

        public void Move()
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        public void Jump()
        {
            if (IsGrounded())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        public void Fly()
        {            
            rb.AddForce(Vector2.up * flyForce);
        }

        public bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector3.down, 0.1f, LayerMask.GetMask("Ground"));
            return hit.collider != null;
        }
    }
}