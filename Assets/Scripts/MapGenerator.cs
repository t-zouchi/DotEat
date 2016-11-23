using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

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
  }
	
	// Update is called once per frame
	void Update () {
	
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
