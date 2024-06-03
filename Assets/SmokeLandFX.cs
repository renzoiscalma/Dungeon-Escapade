using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeLandFX : MonoBehaviour
{
  // Start is called before the first frame update
  Animator animator;
  void Start()
  {
    animator = GetComponent<Animator>();
  }

  public void Play()
  {
    if (animator == null)
    {
      animator = GetComponent<Animator>();
    }
    gameObject.SetActive(true);
    animator.SetTrigger("play");
  }

  void Hide()
  {
    gameObject.SetActive(false);
    Destroy(gameObject);
  }
}
