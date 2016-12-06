using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

  static int level;
	// Use this for initialization
	void Start () {
    levelReset();
	}

  public static void levelUp()
  {
    level++;
  }

  public static void levelReset()
  {
    level = 1;
  }

  public static int getLevel()
  {
    return level;
  }
	}
