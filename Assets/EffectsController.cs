using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{

  [SerializeField] private GameObject smokeLandFX;
  [SerializeField] private GameObject smokeJumpFX;
  private static readonly Vector3 jumpSmokeOffset = new(-0.75f, 0f);
  private static readonly Vector3 landSmokeOffset = new Vector3(-0.75f, -0.6f);

  public void PlayJumpSmoke(Transform transform)
  {
    Debug.Log("playing jump smoke fx");
    GameObject jumpSmokeFx = Instantiate(smokeJumpFX);
    jumpSmokeFx.transform.position = transform.position + jumpSmokeOffset;
    jumpSmokeFx.GetComponent<SmokeJumpFX>().Play();
  }

  public void PlayLandSmoke(Transform transform)
  {
    GameObject landSmokeFx = Instantiate(smokeLandFX);
    landSmokeFx.transform.position = transform.position + landSmokeOffset;
    landSmokeFx.GetComponent<SmokeLandFX>().Play();
  }
}
