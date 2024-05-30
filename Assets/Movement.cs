using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  [SerializeField] Vector2 jumpForce = new Vector2(0, 10);
  [SerializeField] UIController uiController;
  [SerializeField] SingletonGlobalValues globals;
  Rigidbody2D rgb2d;
  PlayerAnimator animator;
  GroundChecker groundChecker;
  DebrisGenerator debrisGenerator;
  SmokeController smokeController;
  public int jumpCount = 0;
  public int maxJumps = 2;
  public bool dead = false;
  void Start()
  {
    rgb2d = GetComponent<Rigidbody2D>();
    debrisGenerator = GetComponent<DebrisGenerator>();
    animator = GetComponentInChildren<PlayerAnimator>();
    groundChecker = GetComponentInChildren<GroundChecker>();
    smokeController = GetComponentInChildren<SmokeController>();
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
        if (groundChecker.grounded)
        {
          smokeController.PlayJumpSmoke(transform);
        }
      }
    }
  }

  void OnCollisionStay2D(Collision2D other)
  {
    if (!dead
      && (other.collider.transform.CompareTag("Deadly")
      || other.collider.gameObject.name.Contains("Spikes")))
    {
      animator.TriggerDeath();
      dead = true;
      globals.StopObstacleAndFloor();
      uiController.ShowRestart();
      debrisGenerator.DispenseDebris(transform);
      return;
    }
    if (groundChecker.grounded)
    {
      jumpCount = 0;
    }
  }
}
