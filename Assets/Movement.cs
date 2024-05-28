using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  [SerializeField] Vector2 jumpForce = new Vector2(0, 10);
  Rigidbody2D rgb2d;
  public bool finishedJumping = true;
  void Start()
  {
    rgb2d = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);
      if (touch.phase == TouchPhase.Ended && finishedJumping)
      {
        finishedJumping = false;
        rgb2d.velocity = jumpForce;
      }
    }
    Debug.Log(rgb2d.velocity);
  }

  void OnCollisionStay2D(Collision2D other)
  {

    if (other.gameObject.CompareTag("Floor") && rgb2d.velocity.y <= 0 && !finishedJumping)
    {
      Debug.Log("touching something");
      finishedJumping = true;
    }
  }
}
