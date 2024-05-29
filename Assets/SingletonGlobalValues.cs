using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;

public class SingletonGlobalValues : MonoBehaviour
{
  // [SerializeField] protected float floorObstacleSpeed = 5;
  private static readonly float startingBackgroundSpeed = 2f;
  private static readonly float startingObstacleSpeed = 5f;
  protected float floorObstacleSpeed = startingObstacleSpeed;
  protected float backgroundSpeed = startingBackgroundSpeed;
  private bool gameStopped;
  private static readonly float zeroSpeed;
  private static SingletonGlobalValues _Instance;
  public static SingletonGlobalValues Instance
  {
    get
    {
      if (!_Instance)
      {
        _Instance = new GameObject().AddComponent<SingletonGlobalValues>();
        _Instance.name = _Instance.GetType().ToString();
        DontDestroyOnLoad(_Instance.gameObject);
      }
      return _Instance;
    }
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void StopObstacleAndFloor()
  {
    gameStopped = true;
  }

  public void StartObstacleAndFloor()
  {
    gameStopped = false;
  }

  public void IncrementFloorObstacleSpeed(float speedIncrease)
  {
    floorObstacleSpeed += speedIncrease;
  }

  public float GetFloorObstacleSpeed()
  {
    if (gameStopped) return zeroSpeed;
    return floorObstacleSpeed;
  }

  public void IncrementBackgroundSpeed(float speedIncrease)
  {
    backgroundSpeed += speedIncrease;
  }

  public float GetBackgroundSpeed()
  {
    if (gameStopped) return zeroSpeed;
    return backgroundSpeed;
  }

  public void ResetSpeed()
  {
    floorObstacleSpeed = startingObstacleSpeed;
    backgroundSpeed = startingBackgroundSpeed;
  }

  public bool GetGameStopped()
  {
    return gameStopped;
  }
}
