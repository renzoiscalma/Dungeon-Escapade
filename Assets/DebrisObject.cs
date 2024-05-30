using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisObject : MonoBehaviour
{
  public void Init(Color color, Vector2 direction, float scale)
  {
    GetComponent<SpriteRenderer>().color = color;
    GetComponent<Transform>().localScale *= scale;
    GetComponent<Rigidbody2D>().velocity = direction;
  }
  void OnBecameInvisible()
  {
    Destroy(gameObject);
  }
}
