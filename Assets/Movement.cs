using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  [SerializeField] Vector2 jumpForce = new Vector2(0, 10);
  [SerializeField] SingletonGlobalValues globals;
  Rigidbody2D rgb2d;
  PlayerAnimator animator;
  public bool finishedJumping = true;
  static readonly float contactRangeMin = -3.70f;
  static readonly float contactRangeMax = -3.4f;
  public bool dead = false;
  void Start()
  {
    rgb2d = GetComponent<Rigidbody2D>();
    animator = GetComponentInChildren<PlayerAnimator>();
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
  }

  void OnCollisionStay2D(Collision2D other)
  {
    if (other.collider.transform.CompareTag("Deadly"))
    {
      animator.TriggerDeath();
      dead = true;
      globals.StopObstacleAndFloor();
      return;
    }
    if (rgb2d.velocity.y <= 0
      && other.contacts[0].point.y <= contactRangeMax
      && other.contacts[0].point.y > contactRangeMin
      && !finishedJumping)
    {
      finishedJumping = true;
    }
  }
}
