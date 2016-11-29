using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

  Rigidbody m_Rigidbody;
  // Use this for initialization
  void Start () {
    m_Rigidbody = GetComponent<Rigidbody>();
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
      x += 1.0f;
    }
    if (Input.GetKey(KeyCode.A))
    {
      x -= 1.0f;
    }
    if (Input.GetKey(KeyCode.W))
    {
      z += 1.0f;
    }
    if (Input.GetKey(KeyCode.S))
    {
      z -= 1.0f;
    }

    if (Input.GetButtonDown("Jump"))
    {
      y += 20f; //ジャンプするベクトルの代入
    }
    else
    {
      if ( y >= 0)
      {
        y = y * 0.1f ;
      }
    }

    m_Rigidbody.velocity = z * transform.forward +y * transform.up + x * transform.right;
  }
}
