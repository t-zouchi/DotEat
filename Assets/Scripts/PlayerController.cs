using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

  Rigidbody m_Rigidbody;
  float speed = 4f;
  int upCount = 0;
  int downCount = 0;
  bool changeRotateFlg = false;
  public GameObject Explosion;
  public GameObject mapGenerator;
  PointManager pointManager;
  int point;
  int life;
  int level;
  
  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
    mapGenerator = GameObject.Find("MapGenerator");
    pointManager = mapGenerator.GetComponent<PointManager>();
    life = 3;
    point = 0;
    level = LevelManager.getLevel();
    pointManager.pointUpdate(point, level);
  }

  void Update() {

    if (Input.GetKey(KeyCode.RightArrow))
    {
      transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
    }
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      transform.Rotate(new Vector3(0.0f, -1.0f, 0.0f));
    }
    if (Input.GetKey(KeyCode.UpArrow))
    {
      if((-6f<= transform.localEulerAngles.x && transform.localEulerAngles.x < 5f )|| transform.localEulerAngles.x  > 345f)
      {
        transform.Rotate(new Vector3(-1.0f, 0.0f, 0.0f));
      }
      changeRotateFlg = true;
    }
    if (Input.GetKey(KeyCode.DownArrow))
    {
      if (transform.localEulerAngles.x < 15f)
      {
        transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f));
      }

      changeRotateFlg = true;
    }
    if (changeRotateFlg)
    {
      if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
      {
      }
      else
      {
        transform.Rotate(new Vector3(-transform.localEulerAngles.x, 0.0f, -transform.localEulerAngles.z));
        changeRotateFlg = false;

      }
    }

    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
  

    if (Input.GetKey(KeyCode.D))
    {
      x += speed;
    }
    if (Input.GetKey(KeyCode.A))
    {
      x -= speed;
    }
    if (Input.GetKey(KeyCode.W))
    {
      z += speed;
    }
    if (Input.GetKey(KeyCode.S))
    {
      z -= speed;
    }

    if (Input.GetButtonDown("Jump"))
    {
      y += 20f; 
    }
    else
    {
      if ( y >= 0)
      {
        y = y * 0.01f ;
      }
    }

    m_Rigidbody.velocity = z * transform.forward +y * transform.up + x * transform.right;
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Dot")
    {

      point++;
      if(point == level * 50)
      {
        level++;
        LevelManager.levelUp();
        SceneManager.LoadScene("Main");        
      }
      else
      {
        pointManager.pointUpdate(point, level);
      }
      Destroy(collision.gameObject);
    }

    if (collision.gameObject.tag == "Bom")
    {

      for (int aIndex = 0; aIndex < collision.contacts.Length; ++aIndex)
      {
        Instantiate(Explosion, m_Rigidbody.transform.position, Quaternion.identity);
      }
      life--;
      if(life > 0)
      {
        pointManager.lifeUpdate(life);
      }
      else
      {
        LevelManager.levelReset();
        SceneManager.LoadScene("GameOver");
      }
       Destroy(collision.gameObject);
    }
  }

}
