using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointManager : MonoBehaviour {

  public Canvas canvas;
  static Text pointText;
  static Text lifeText;

  int life;
  int point;

  // Use this for initialization
  void Start () {
    life = 3;
    point = 0;
    foreach (Transform child in canvas.transform)
    {
      if (child.name == "Point")
      {
        pointText = child.gameObject.GetComponent<Text>();
        pointText.transform.SetParent(canvas.transform, false);
        pointText.text = "Point : " + point ;
      }
      if (child.name == "Life")
      {
        lifeText = child.gameObject.GetComponent<Text>();
        lifeText.transform.SetParent(canvas.transform, false);
        lifeText.text = "Life : " + life;
      }
    }
  }

  // Update is called once per frame
  void Update () {
	
	}

  public void lifeUpdate(int life)
  {

    foreach (Transform child in canvas.transform)
    {
      if (child.name == "Life")
      {
        lifeText = child.gameObject.GetComponent<Text>();
        lifeText.transform.SetParent(canvas.transform, false);
        lifeText.text = "Life : " + life;
      }
    }
  }

  public void pointUpdate(int point)
  {
    foreach (Transform child in canvas.transform)
    {
      if (child.name == "Point")
      {
        pointText = child.gameObject.GetComponent<Text>();
        pointText.transform.SetParent(canvas.transform, false);
        pointText.text = "Point : " + point;
      }
    }

  }
}
