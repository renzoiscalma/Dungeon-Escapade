using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
  [SerializeField] SingletonGlobalValues globals;
  private TextComponent textController;
  // Start is called before the first frame update
  void Start()
  {
    textController = GetComponentInChildren<TextComponent>();
  }

  // Update is called once per frame
  void Update()
  {
    textController.SetText("Score: " + globals.score.ToString("F3"));
  }
}
