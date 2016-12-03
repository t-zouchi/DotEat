using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

  Rigidbody m_Rigidbody;
  float speed = 1f;
  float counter = 0f;
  int upCount = 0;
  int downCount = 0;
  bool changeRotateFlg = false;
  public GameObject Explosion;
  // Use this for initialization
  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
    counter = 0f;
  }

  // Update is called once per frame
  void Update() {
    // 十字キーで首を左右に回す
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
      if(transform.localEulerAngles.x == 0 || transform.localEulerAngles.x  > 345f)
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


    // WASDで移動する
    //スペースでジャンプする
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
      y += 20f; //ジャンプするベクトルの代入
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
      counter++;
      if(counter % 10 == 0)
      {
        speed++;
      }
      Destroy(collision.gameObject);
    }

    if (collision.gameObject.tag == "Bom")
    {

      for (int aIndex = 0; aIndex < collision.contacts.Length; ++aIndex)
      {
        Debug.Log(collision.contacts[aIndex].point);
        Instantiate(Explosion, m_Rigidbody.transform.position, Quaternion.identity);
      }
      Destroy(collision.gameObject);
    }
  }

}
