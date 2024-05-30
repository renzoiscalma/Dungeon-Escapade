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
    Debug.Log("Play!");
    gameObject.SetActive(true);
    animator.SetTrigger("play");
  }

  void Hide()
  {
    Debug.Log("Hide");
    gameObject.SetActive(false);
  }
}
