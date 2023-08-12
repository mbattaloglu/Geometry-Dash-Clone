namespace Game.Player.Abstract.Movement
{
    public interface IPlayerMovement
    {
        void Move();
        void Jump();
        void Fly();
        bool IsGrounded();
    }
}
