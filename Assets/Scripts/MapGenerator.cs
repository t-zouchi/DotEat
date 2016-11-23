using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

  public GameObject Cube;
	// Use this for initialization
	void Start () {
    //マップの初期化
    // ０は壁
    // [偶数,偶数],[奇数,奇数]にクラスタ番号を振っていく
    int[][] mapArray = new int[31][];
    int[] defaultArray = new int[31] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    for(int i = 0; i < mapArray.Length; i++)
    {
      int[] copyArray = (int[])defaultArray.Clone();
      mapArray[i] = copyArray;
    }
    //deBugger(mapArray);

    //初期化していく
    int clusterNum = 0;
    for(int i = 0; i < mapArray.Length; i++)
    {
      for(int j = 0; j < mapArray.Length; j++)
      {
        if(i == 0 | i ==30 | j == 0 | j == 30)
        {
          mapArray[i][j] = 0;
          continue;
        }

        if(i % 2 == j % 2)
        {
          clusterNum++;
          mapArray[i][j] = clusterNum;
          Debug.Log( clusterNum.ToString() + ", "+ mapArray[i][j].ToString());
        }
      }
    }
    deBugger(mapArray);
    int[][] testArr = new int[3][];
    int[] testArr2 = new int[] { 0, 0, 0 };
    int[] testArr3 = new int[] { 0, 1, 0 };
    testArr[0] = testArr2;
    testArr[1] = testArr3;
    testArr[2] = testArr2;
    //generateMap(testArr);
    generateMap(mapArray);
  }
	
	// Update is called once per frame
	void Update () {
	
	}

  void generateMap(int[][] mapArray)
  {
    float x = 0;
    float y = 0;
    float z = 0;
    float distance = 1.5f;
    for(int i = 0; i < mapArray.Length; i++)
    {
      for(int j = 0; j < mapArray[i].Length; j++)
      {
        x = distance * j;
        z = distance * i;
        Debug.Log("x = " + x + "z = " + z); 
        transform.position = new Vector3(x, y, z);
        if (mapArray[i][j] == 0f)
        {
          Instantiate(Cube, transform.position, transform.rotation);
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
