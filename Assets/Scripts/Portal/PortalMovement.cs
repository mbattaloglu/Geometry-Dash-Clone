using UnityEngine;


namespace Game.Portal.PortalMovement
{
    public class PortalMovement : MonoBehaviour
    {
        private void Update()
        {
            transform.position += Vector3.left * 8 * Time.deltaTime;
        }
    }
}
