using Game.Player.Abstract.Input;

namespace Game.Player.Concreates.Input
{
    public class PlayerInput : IPlayerInput
    {
        public bool Jump => UnityEngine.Input.GetMouseButtonDown(0);
        public bool Holding => UnityEngine.Input.GetMouseButton(0);
    }
}
