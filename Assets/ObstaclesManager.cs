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

  DebrisGenerator debrisGenerator;
  // currenct obstacles in the manager
  public List<Transform> obstacles;
  // Start is called before the first frame update
  void Start()
  {
    obstacles = GetComponentsInChildren<Transform>().ToList();
    debrisGenerator = GetComponent<DebrisGenerator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (globals.GetGameStopped()) return;
    foreach (var obs in obstacles)
    {
      if (obs == null || (!obs.CompareTag("Obstacle") && !obs.CompareTag("ComboObstacle"))) continue;
      obs.transform.Translate(globals.GetFloorObstacleSpeed() * Time.deltaTime * Vector3.left);
    }
    currSpawnTimer -= Time.deltaTime;
    if (currSpawnTimer <= 0)
    {
      int randIdx = Random.Range(0, possibleObstacles.Length);
      GameObject newObstacle = Instantiate(possibleObstacles[randIdx], transform);
      // newObstacle.transform.position = transform.position;
      obstacles.Add(newObstacle.GetComponent<Transform>());
      currSpawnTimer = spawnTimer;
    }
  }

  public void DestroyObstacle(GameObject obstacle)
  {
    var parent = obstacle.transform.parent;
    debrisGenerator.DispenseDebris(obstacle.transform);
    obstacles.Remove(obstacle.GetComponent<Transform>());
    Destroy(obstacle);
    if (parent.CompareTag("ComboObstacle") && parent.GetComponentsInChildren<Obstacle>().Length == 1)
    {
      Destroy(parent.gameObject);
    }
  }
}
