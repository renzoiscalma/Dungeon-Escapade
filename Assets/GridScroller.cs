using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScroller : MonoBehaviour
{
  [SerializeField] GameObject[] floorGrids;
  [SerializeField] GameObject[] backgroundGrids;
  // background speed for parallax effect
  [SerializeField] float backgroundSpeed = 2f;
  // floor speed 
  [SerializeField] float floorSpeed = 5f;
  // Start is called before the first frame update
  void Start()
  {

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
        floorGrids[i].transform.Translate(floorSpeed * Time.deltaTime * Vector3.left);
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
        backgroundGrids[i].transform.Translate(backgroundSpeed * Time.deltaTime * Vector3.left);
      }
    }
  }
}
