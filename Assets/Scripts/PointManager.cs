using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {

  public Canvas canvas;
  static Text pointText;
  static Text lifeText;

  int life;
  int point;
  int level;

  void Start () {
    life = 3;
    point = 0;
    level = 1;
    foreach (Transform child in canvas.transform)
    {
      if (child.name == "Point")
      {
        pointText = child.gameObject.GetComponent<Text>();
        pointText.transform.SetParent(canvas.transform, false);
        pointText.text = "Point : " + point  + " / " + level * 50;
      }
      if (child.name == "Life")
      {
        lifeText = child.gameObject.GetComponent<Text>();
        lifeText.transform.SetParent(canvas.transform, false);
        lifeText.text = "Life : " + life;
      }
    }
  }

  public void saveLevel(int currentlevel)
  {
    level = currentlevel;
  }

  public int getLevel()
  {
    return level;
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

  public void pointUpdate(int point, int level)
  {
    foreach (Transform child in canvas.transform)
    {
      if (child.name == "Point")
      {
        pointText = child.gameObject.GetComponent<Text>();
        pointText.transform.SetParent(canvas.transform, false);
        pointText.text = "Point : " + point + " / " + level * 50;
      }
    }
  }
}
