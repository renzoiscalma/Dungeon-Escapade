using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeController : MonoBehaviour
{
  private Vector3 feetOffset = new(-0.75f, -0.6f);
  private SmokeLandFX smokeLandFX;
  private SmokeJumpFX smokeJumpFX;
  void Start()
  {
    smokeLandFX = GetComponentInChildren<SmokeLandFX>(true);
    smokeJumpFX = GetComponentInChildren<SmokeJumpFX>(true);
  }

  public void PlayJumpSmoke(Transform transform)
  {
    smokeJumpFX.transform.position = transform.position + feetOffset;
    smokeJumpFX.Play();
    // gameObject.SetActive(true);
    // animator.SetTrigger("jump");
    // this.transform.position = transform.position + feetOffset;
  }

  public void PlayLandSmoke(Transform transform)
  {
    smokeLandFX.Play();
    smokeLandFX.transform.position = transform.position + feetOffset;
  }
}
