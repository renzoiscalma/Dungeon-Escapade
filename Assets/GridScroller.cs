using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScroller : MonoBehaviour
{
  [SerializeField] GameObject[] floorGrids;
  [SerializeField] GameObject[] backgroundGrids;
  [SerializeField] Movement player;
  [SerializeField] SingletonGlobalValues globals;
  Rigidbody2D[] floorRb2d;
  void Start()
  {
    floorRb2d = new Rigidbody2D[floorGrids.Length];
    for (int i = 0; i < floorRb2d.Length; i++)
    {
      floorRb2d[i] = floorGrids[i].GetComponentInChildren<Rigidbody2D>();
    }
  }

  // Update is called once per frame
  void Update()
  {
    moveFloorGrids();
    movebackgrounds();
  }

  public void moveFloorGrids()
  {
    for (int i = 0; i < floorGrids.Length; i++)
    {
      if (floorGrids[i].transform.position.x <= -25)
      {
        floorGrids[i].transform.position = new(24, 0);
      }
      else
      {
        floorGrids[i].transform.Translate(globals.GetFloorObstacleSpeed() * Time.deltaTime * Vector3.left);
      }
    }
  }

  public void movebackgrounds()
  {
    for (int i = 0; i < backgroundGrids.Length; i++)
    {
      if (backgroundGrids[i].transform.position.x <= -27)
      {
        backgroundGrids[i].transform.position = new(25, 0);
      }
      else
      {
        backgroundGrids[i].transform.Translate(globals.GetBackgroundSpeed() * Time.deltaTime * Vector3.left);
      }
    }
  }
}
