using UnityEngine;

public class GroundChecker : MonoBehaviour
{
  public bool grounded = true;
  [SerializeField] EffectsController effectsController;
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
      effectsController.PlayLandSmoke(transform.parent);
    }
  }
}
