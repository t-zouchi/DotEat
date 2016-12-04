using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scene : MonoBehaviour {

  // Use this for initialization
  public void start()
  {
    SceneManager.LoadScene("Main");
  }

  public void Title()
  {
    SceneManager.LoadScene("Title");
  }

}
