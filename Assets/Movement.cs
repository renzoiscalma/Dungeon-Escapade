using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  [SerializeField] Vector2 jumpForce = new Vector2(0, 10);
  [SerializeField] SingletonGlobalValues globals;
  Rigidbody2D rgb2d;
  PlayerAnimator animator;
  GroundChecker groundChecker;
  public bool finishedJumping = true;
  public int jumpCount = 0;
  public int maxJumps = 2;
  static readonly float contactRangeMin = -3.70f;
  static readonly float contactRangeMax = -3.4f;
  public bool dead = false;
  void Start()
  {
    rgb2d = GetComponent<Rigidbody2D>();
    animator = GetComponentInChildren<PlayerAnimator>();
    groundChecker = GetComponentInChildren<GroundChecker>();

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);
      if (touch.phase == TouchPhase.Ended && jumpCount < maxJumps)
      {
        jumpCount++;
        rgb2d.velocity = jumpForce;
        if (jumpCount >= maxJumps)
        {
          finishedJumping = false;
        }
      }
    }
  }

  void OnCollisionStay2D(Collision2D other)
  {
    if (other.collider.transform.CompareTag("Deadly") || other.collider.gameObject.name.Contains("Spikes"))
    {
      animator.TriggerDeath();
      dead = true;
      globals.StopObstacleAndFloor();
      return;
    }
    if (groundChecker.grounded)
    {
      finishedJumping = true;
      jumpCount = 0;
    }
  }
}
