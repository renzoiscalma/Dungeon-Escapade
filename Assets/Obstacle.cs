using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  ObstaclesManager manager;
  Rigidbody2D rb2d;
  public int id;

  void Start()
  {
    manager = GetComponentInParent<ObstaclesManager>();
    rb2d = GetComponent<Rigidbody2D>();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.transform.CompareTag("Deadly"))
    {
      manager.DestroyObstacle(transform.gameObject);
    }
  }
}
