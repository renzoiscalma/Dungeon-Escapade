using UnityEngine;

public class GroundChecker : MonoBehaviour
{
  public bool grounded = true;

  SmokeController smokeController;

  void Start()
  {
    smokeController = transform.parent.GetComponentInChildren<SmokeController>();
  }

  void OnTriggerStay2D(Collider2D col)
  {
    grounded = true;
  }

  void OnTriggerExit2D(Collider2D col)
  {
    grounded = false;
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (!grounded)
    {
      smokeController.PlayLandSmoke(transform.parent);
    }
  }
}
