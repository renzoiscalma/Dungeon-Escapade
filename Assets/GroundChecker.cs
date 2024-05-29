using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
  public bool grounded = true;

  void OnTriggerStay2D(Collider2D col)
  {
    grounded = true;
  }

  void OnTriggerExit2D(Collider2D col)
  {
    grounded = false;
  }
}
