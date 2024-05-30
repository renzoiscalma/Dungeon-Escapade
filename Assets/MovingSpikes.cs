using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpikes : MonoBehaviour
{
  Vector3 basePosition;
  float minXMovement = -0.05f;
  float minYMovement = -0.05f;
  float maxXMovement = 0.05f;
  float maxYMovement = 0.05f;
  // Start is called before the first frame update
  void Start()
  {
    basePosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    float x = Random.Range(minXMovement, maxXMovement);
    float y = Random.Range(minYMovement, maxYMovement);
    transform.position = basePosition + new Vector3(x, y, 0);
  }
}
