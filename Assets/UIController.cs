using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIController : MonoBehaviour
{

  public int score = 0;
  [SerializeField] TextComponent textScoreComponent;
  [SerializeField] SingletonGlobalValues globals;
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void RestartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    globals.RestartValues();
    gameObject.SetActive(false);
  }

  public void ShowRestart(float score = 0f)
  {
    Debug.Log("Should show here");
    textScoreComponent.SetText("Your score: " + score);
    gameObject.SetActive(true);
  }
}
