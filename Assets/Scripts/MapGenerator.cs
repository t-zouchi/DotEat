using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MapGenerator : MonoBehaviour {

  public GameObject Cube;
  public GameObject Sphere;
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
    //    deBugger(mapArray);

    clustering(mapArray);
    //generateMap(mapArray);
  }
	
	// Update is called once per frame
	void Update () {
	
	}

  void clustering(int[][] mapArray)
  {
    //広げるクラスを決める
    //ランダムに座標を選ぶ
    int random_x = 0;
    int random_y = 0;
    int target_x = 0;
    int target_y = 0;
    int clusternums = 0;
    int direction = 0; //0:上　1: 右　2:下　3:左
    clusternums = clusterCount(mapArray);
    Debug.Log(clusternums);

    //クラスタが1個になるまで繰り返す
    while(clusternums > 1)
    {
      random_x = Random.Range(1, 30);
      random_y = Random.Range(1, 30);
      //
      if (mapArray[random_y][random_x] == 0)
      {
        //ランダムに選んだ場所がブロックの場合やり直す
        continue;
      }
      else
      {
        //壊す場所を決める
        //上下左右どっちに進むか決める
        direction = Random.Range(1, 4);
        if(direction == 0)
        {
          target_x = random_x;
          target_y = random_y + 1;
        }else if(direction == 1)
        {
          target_x = random_x + 1;
          target_y = random_y;
        }else if(direction == 2)
        {
          target_x = random_x;
          target_y = random_y - 1;
        }else if(direction == 3)
        {
          target_x = random_x - 1;
          target_y = random_y;
        }

        //壊せれるかチェックする

      }

      clusternums = clusterCount(mapArray);
    }

  }

  //クラスタ数を数える関数
  int clusterCount(int[][] mapArray)
  {
    Dictionary<int, int> clusterDict = new Dictionary<int, int>();
    for(int i = 0; i < mapArray.Length; i++)
    {
      for (int j = 0; j < mapArray.Length; j++)
      {
        if(mapArray[i][j] != 0 && !clusterDict.ContainsKey(mapArray[i][j]))
        {
          clusterDict.Add(mapArray[i][j], 0);
        }
      }
    }
    return clusterDict.Keys.Count;
  }

  void generateMap(int[][] mapArray)
  {
    float x = 0;
    float y = 0.5f;
    float z = 0;
    float distance = 1.5f;
    for(int i = 0; i < mapArray.Length; i++)
    {
      for(int j = 0; j < mapArray[i].Length; j++)
      {
        x = distance * j;
        z = distance * i;
        transform.position = new Vector3(x, y, z);
        if (mapArray[i][j] == 0f)
        {
          Instantiate(Cube, transform.position, transform.rotation);
        }
        else
        {
          Instantiate(Sphere, transform.position, transform.rotation);
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
