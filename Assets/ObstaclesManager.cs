using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
  [SerializeField] GameObject[] possibleObstacles;
  [SerializeField] float spawnTimer = 2;
  [SerializeField] SingletonGlobalValues globals;
  private float currSpawnTimer = 0;
  // currenct obstacles in the manager
  public List<Rigidbody2D> obstacles;
  private int counter = 0;
  // Start is called before the first frame update
  void Start()
  {
    obstacles = GetComponentsInChildren<Rigidbody2D>().ToList();
    foreach (Rigidbody2D t in obstacles)
    {
      t.GetComponent<Obstacle>().id = counter++;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (globals.GetGameStopped()) return;
    foreach (var obs in obstacles)
    {
      if (obs == null || !obs.CompareTag("Obstacle")) continue;
      obs.transform.Translate(globals.GetFloorObstacleSpeed() * Time.deltaTime * Vector3.left);
    }
    currSpawnTimer -= Time.deltaTime;
    if (currSpawnTimer <= 0)
    {
      int randIdx = Random.Range(0, possibleObstacles.Length);
      GameObject newObstacle = Instantiate(possibleObstacles[randIdx], transform);
      newObstacle.transform.position = transform.position;
      obstacles.Add(newObstacle.GetComponent<Rigidbody2D>());
      currSpawnTimer = spawnTimer;
    }
  }

  public void DestroyObstacle(GameObject obstacle)
  {
    obstacles.Remove(obstacle.GetComponent<Rigidbody2D>());
    Destroy(obstacle);
  }
}
