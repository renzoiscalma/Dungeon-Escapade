using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextComponent : MonoBehaviour
{
  public void SetText(string text)
  {
    transform.GetComponent<TextMeshProUGUI>().text = text;
  }
}
