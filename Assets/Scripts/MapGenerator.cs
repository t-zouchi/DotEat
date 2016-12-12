using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class MapGenerator : MonoBehaviour {

  public GameObject Cube;
  public GameObject Sphere;
  public GameObject Player;
  public GameObject Bom;
  public GameObject Center;

  GameObject Generator;
	// Use this for initialization
	void Start () {
    Generator = GameObject.Find("MapGenerator");
    ProvMap provMap = Generator.GetComponent<ProvMap>();
    ProvMap2 provMap2 = Generator.GetComponent<ProvMap2>();
    ProvMap3 provMap3 = Generator.GetComponent<ProvMap3>();
    ProvMap4 provMap4 = Generator.GetComponent<ProvMap4>();
    ProvMap5 provMap5 = Generator.GetComponent<ProvMap5>();
    int[][] map = new int[31][];

    map = provMap.getProvMap();
    generateMap(map, 0);
    map = provMap2.getProvMap();
    generateMap(map, 1);
    map = provMap3.getProvMap();
    generateMap(map, 2);
    map = provMap4.getProvMap();
    generateMap(map, 3);
    map = provMap5.getProvMap();
    generateMap(map, 4);
  }

  void generateMap(int[][] mapArray, int layer)
  {
    float x = 0;
    float y = 0.5f + layer * 1.5f;
    float player_y = 3.5f;
    float z = 0;
    float distance = 1.5f;
    for (int i = 0; i < mapArray.Length; i++)
    {
      for (int j = 0; j < mapArray[i].Length; j++)
      {
        x = distance * j;
        z = distance * i;
        transform.position = new Vector3(x, y, z);
        if (mapArray[i][j] == 0f)
        {
          Instantiate(Cube, transform.position, transform.rotation);
        }
        else if(mapArray[i][j] == 1f)
        {
          Instantiate(Sphere, transform.position, transform.rotation);
        }
        else if (mapArray[i][j] == 2f)
        {
          Instantiate(Bom, transform.position, transform.rotation);
        }
        else if (mapArray[i][j] == 3f)
        {
          Instantiate(Cube, transform.position, transform.rotation);
          transform.position = new Vector3(x, player_y, z);
          Instantiate(Player, transform.position, transform.localRotation);
          GameObject currentPlayer = GameObject.Find("Player(Clone)");
          currentPlayer.transform.LookAt(Center.transform.position);
        }
        else
        {
          //なにもつくらない
        }
      }
    }
  }

  //プリントデバッグするためのやつ
  void deBugger(int[][] mapArray)
  {
    string str = "";
    for (int i = 0; i < mapArray.Length; i++)
    {
      for (int j = 0; j < mapArray[i].Length; j++)
      {
        str = str + " " + mapArray[i][j].ToString();
      }
      str = str + "\n";
    }
    Debug.Log(str);
  }

}
