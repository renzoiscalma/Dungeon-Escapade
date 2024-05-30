using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisGenerator : MonoBehaviour
{
  public GameObject debrisParticle;
  public int debrisAmountMin = 10;
  public int debrisAmountMax = 20;
  public float debrisScaleMin = 2f;
  public float debrisScaleMax = 5f;
  public float debrisSpeedMin = 2f;
  public float debrisSpeedMax = 4f;
  public Color[] possibleDebrisColors;
  public Vector2 debrisDirection;
  public int debrisDispenseDegrees;
  void Update()
  {
  }

  public void DispenseDebris(Transform transform)
  {
    int debrisAmount = Random.Range(debrisAmountMin, debrisAmountMax);

    for (int i = 0; i < debrisAmount; i++)
    {
      int debrisColorIdx = Random.Range(0, possibleDebrisColors.Length - 1);
      Color debrisColor = possibleDebrisColors[debrisColorIdx];

      DebrisObject debrisObject = Instantiate(debrisParticle, transform.position, Quaternion.identity).GetComponent<DebrisObject>();
      debrisObject.transform.position = transform.position;
      float scale = Random.Range(debrisScaleMin, debrisScaleMax);
      // debrisObject.trnsBody.GetComponent<SpriteRenderer>().color = debrisParticleColor;

      float randomizedDirectionAngle = Mathf.Atan2(debrisDirection.y, debrisDirection.x) + (Random.Range(-debrisDispenseDegrees / 2, debrisDispenseDegrees / 2) * Mathf.Deg2Rad);
      debrisDirection.x = Mathf.Cos(randomizedDirectionAngle);
      debrisDirection.y = Mathf.Sin(randomizedDirectionAngle);
      debrisDirection.Normalize();
      Vector2 debrisVelocity = debrisDirection * (Vector2.one * Random.Range(debrisSpeedMin, debrisSpeedMax));

      debrisObject.Init(debrisColor, debrisVelocity, scale);

    }


  }
}
