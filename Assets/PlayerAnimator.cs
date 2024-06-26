using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
  public Rigidbody2D playerRb2d;
  public Movement pMovement;
  private GroundChecker groundChecker;
  Animator pAnimator;
  bool running = true;
  bool falling = false;
  bool rising = false;
  bool death = false;
  void Start()
  {
    playerRb2d = GetComponentInParent<Rigidbody2D>();
    pMovement = GetComponentInParent<Movement>();
    pAnimator = GetComponent<Animator>();
    groundChecker = transform.parent.GetComponentInChildren<GroundChecker>();
  }

  void Update()
  {
    if (death)
    {
      pAnimator.SetTrigger("death");
      return;
    }
    if (groundChecker.grounded)
    {
      running = true;
      rising = false;
      falling = false;
    }
    else
    if (playerRb2d.velocity.y > 0)
    {
      rising = true;
      running = false;
      falling = false;
    }
    else
    if (playerRb2d.velocity.y < 0)
    {
      rising = false;
      running = false;
      falling = true;
    }
    pAnimator.SetBool("running", running);
    pAnimator.SetBool("falling", falling);
    pAnimator.SetBool("rising", rising);
  }

  public void TriggerDeath()
  {
    death = true;
  }
}
