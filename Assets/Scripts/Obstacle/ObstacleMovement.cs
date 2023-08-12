using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.left * 8 * Time.deltaTime;
    }
}
