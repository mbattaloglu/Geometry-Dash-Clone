using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float spawnFrequency = 3f;
    [SerializeField]
    private GameObject[] obstacles;

    private void OnEnable()
    {
        StartCoroutine(SpawnObstacles());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnObstacles()
    {

        yield return new WaitForSeconds(spawnFrequency / 2f);
        foreach (GameObject obstacle in obstacles)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, obstacle.transform.position.y, obstacle.transform.position.z);
            Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
            yield return new WaitForSeconds(spawnFrequency);
        }
    }
}
