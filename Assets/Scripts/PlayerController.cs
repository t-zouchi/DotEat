using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

  Rigidbody m_Rigidbody;
  float speed = 1f;
  float counter = 0f;
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
      Debug.Log("hit!!");
      counter++;
      if(counter % 10 == 0)
      {
        speed++;
      }
      Destroy(collision.gameObject);
    }
  }

}
