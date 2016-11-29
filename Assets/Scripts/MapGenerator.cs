using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class MapGenerator : MonoBehaviour {

  public GameObject Cube;
  public GameObject Sphere;
  public GameObject Player;
  GameObject Generator;
	// Use this for initialization
	void Start () {
    //マップの初期化
    // ０は壁
    // [偶数,偶数],[奇数,奇数]にクラスタ番号を振っていく
    Generator = GameObject.Find("MapGenerator");
    ProvMap provMap = Generator.GetComponent<ProvMap>();
    int[][] mapArray = new int[31][];
    int[][] defaultMap = new int[31][];
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
          //Debug.Log( clusterNum.ToString() + ", "+ mapArray[i][j].ToString());
        }
      }
    }
    //deBugger(mapArray);

    for(int i = 0; i < 10; i++)
    {
      int[] rs = getRandoms(mapArray);
    }

    //clustering(mapArray);
    //generateMap(mapArray
    defaultMap = provMap.getProvMap();
    generateMap(defaultMap);
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
    int[] randoms = new int[] { 0, 0 };//random[1] = x random[0] = y
    int[] targets = new int[] { 0, 0 };  //targets[1] = x targets[0] =  y
    int clusternums = 0;
    int direction = 0; //0:上　1: 右　2:下　3:左
    clusternums = clusterCount(mapArray);
    Debug.Log(clusternums);
    int count = 0;


    //クラスタが1個になるまで繰り返す
    //while (clusternums > 350)
    while(count < 10) 
    {
      random_x = Random.Range(1, 29);
      random_y = Random.Range(1, 29);
      randoms = getRandoms(mapArray);
      //
        //Debug.Log("else");

        //壊す場所を決める
        //上下左右どっちに進むか決める
        //direction = getDirection(mapArray, random_x, random_y);
      //修正プラン
      //directionをとる
      //壊せるかどうかのフラグ
      //壊せるならtargetを取得
      //壊せないならrandomの取得からやり直し  
      //壊せないとは端まで進んだのにだめだったときのこと

//        Debug.Log("direction "  + direction);
        //壊せるブロックを決める
        targets = getTargets(mapArray, direction, random_x, random_y);
        //       Debug.Log("x = " + targets[1] + " y = " + targets[0]);
        //クラスタを更新する

        //Debug.Log("random_x = " + random_x + " random_y = " + random_y + " direction" + direction + " cluster = " + mapArray[random_y][random_x]);
        Debug.Log("targets[1] = " + targets[1] + " target[0] = " + targets[0]);
        //deBugger(mapArray);
        mapArray[targets[0]][targets[1]] = mapArray[random_y][random_x];
        //deBugger(mapArray);
        mapArray = changeCluster(mapArray, targets);
        deBugger(mapArray);
        //クラスタ数を数える
        clusternums = clusterCount(mapArray);
        //        Debug.Log(clusternums);
        //deBugger(mapArray);

        //break;
        
      count++;
      clusternums = clusterCount(mapArray);
    }

    //クラスタリングしたマップを投げる
    //generateMap(mapArray);
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
    float player_y = 3.5f;
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
        else if(mapArray[i][j] == 999f)
        {
          Instantiate(Cube, transform.position, transform.rotation);
          transform.position = new Vector3(x, player_y, z);
          Instantiate(Player, transform.position, transform.localRotation);
        }
        else
        {
          Instantiate(Sphere, transform.position, transform.rotation);
        }
      }
    }
  }

  //壊すブロックを決める関数
  int[] getTargets(int[][] mapArray, int direction, int random_x, int random_y)
  {
    //ターゲットの初期値はランダムで選んだ場所からDuration向きに1進んだところ
    int[] targets = new int[2] { 0, 0 };
    bool isBreakable = false;
    direction = getDirection(mapArray, random_x, random_y);
    targets = initializeTraget(random_x, random_y, direction);
    
    //壊せるブロックが見つかるまで繰り返す
    while(isBreakable == false)
    {
      //Debug.Log("random cluster = " + mapArray[targets[1]][targets[0]]);
      //ブロックじゃないときは進む
      if (mapArray[targets[0]][targets[1]] >= 1)
      {
        if (direction == 0)
        {
          targets[0] = targets[0] + 1;
        }
        else if (direction == 1)
        {
          targets[1] = targets[1] + 1;
        }
        else if (direction == 2)
        {
          targets[0] = targets[0] - 1;
        }
        else if (direction == 3)
        {
          targets[1] = targets[1] - 1;
        }
        break;
      }
      else if (mapArray[targets[0]][targets[1]] == 0 )
      {
        //Debug.Log("isBlock");
        
        //ブロックのとき
        //壁か確認
        if (targets[1] <=  0 | targets[1] > mapArray[targets[0]].Length - 1  | targets[0] <= 0 | targets[0] > mapArray.Length -1)
        {
          //壁のとき
          //向きを変える
          direction = changeDirection(direction);
          //targets = getTargets(mapArray, direction, random_x, random_y);
          //isBreakable = true;
        }
        else
        {
          //壁じゃないとき
          //もう1個向こうが同じクラスタじゃないことを確認する
          if (!checkOverCluster(mapArray, targets, direction))
          {
            //壊せる
            isBreakable = true;
          }
          else
          {
            //壊せない
            direction = changeDirection(direction);
            //targets = getTargets(mapArray, direction, random_x, random_y);
            //isBreakable = true;
          }
        }
      }
      targets = initializeTraget(random_x, random_y, direction);
      
    }
    //Debug.Log("targets : x = " + targets[1] + " y = " + targets[0]);
    return targets;
  }

  //クラスタを書き換える関数
  int[][] changeCluster(int[][] mapArray, int[] targets)
  {
    int[][] changedMap = (int[][])mapArray.Clone();
    int changedClusterNum = mapArray[targets[0]][targets[1]];
    int neighborNum = 0;
    int direction = 0;
    int[] neighbor =new int[2]{ 0, 0 };

    //Debug.Log("CCN = " + changedClusterNum);

    //4回回すのはダサいもっといい感じにしたい
    for(int i = 0; i < 4; i++)
    {
      neighbor = initializeTraget(targets[1], targets[0], i);
      //TODO
      //かべにぶつかるときの対策をする
      if (targets[0] <= 0 | targets[0] > mapArray.Length -1 | targets[1] <= 0 | targets[1] > mapArray[targets[0]].Length - 1)
      {
        continue;
      }
      if (neighbor[0] <= 0 | neighbor[0] > mapArray.Length - 1 | neighbor[1] <= 0 | neighbor[1] > mapArray[neighbor[0]].Length - 1)
      {
        continue;
      }
      neighborNum = mapArray[neighbor[0]][neighbor[1]];
      //Debug.Log("changed = " + changedClusterNum + " neibor = " + neighborNum);
      if (changedClusterNum > neighborNum)
      {
        //入れ替える
        changedMap = changeRoop(changedMap, neighborNum, changedClusterNum);
      }
      else
      {
        //入れ替える
        changedMap = changeRoop(changedMap, changedClusterNum, neighborNum);
        changedClusterNum = neighborNum;
      }
    }
    return changedMap;
  }

  //入れ替える関数
  int[][] changeRoop(int[][] changedMap, int targetNum, int changeNum)
  {
    for(int i = 1; i < changedMap.Length-1; i++)
    {
      for(int j = 1; j < changedMap[i].Length-1; j++) {
        if(changedMap[j][i] == targetNum)
        {
          changedMap[j][i] = changeNum;
        }
      }
    }
    return changedMap;
  }

  //クラスタが同じならtrue 違ったらfalse
  bool checkOverCluster(int[][] mapArray, int[] targets, int direction)
  {
    bool flg = false;
    if (direction == 0)
    {
      //壊すブロックの奥が壁のとき
      if(targets[0] + 1 >= mapArray[targets[0]].Length -1)
      {
        return true;
      }
      if (mapArray[targets[0]][targets[1]] == mapArray[targets[0]][targets[1] + 1])
      {
        flg = true;
      }
      else
      {
        flg = false;
      }
    }
    else if (direction == 1)
    {
      if(targets[1] + 1 > mapArray.Length - 1 )
      {
        return true;
      }
      if (mapArray[targets[0]][targets[1]] == mapArray[targets[0] + 1][targets[1]])
      {
        flg = true;
      }
      else
      {
        flg = false;
      }
    }
    else if (direction == 2)
    {
      if(targets[0] - 1  <= 0)
      {
        return true;
      }
      if (mapArray[targets[0]][targets[1]] == mapArray[targets[0]][targets[1] - 1] )
      {
        flg = true;
      }
      else
      {
        flg = false;
      }
    }
    else if (direction == 3)
    {
      if(targets[1] -1 <= 0)
      {
        return true;
      }
      if (mapArray[targets[0] - 1][targets[1]] == mapArray[targets[0]][targets[1]] )
      {
        flg = true;
      }
      else
      {
        flg = false;
      }
    }
    return flg;
  }

  //移動する向きの初期化（壁際のときの処理）
  int getDirection(int[][] mapArray, int random_x, int random_y)
  {
    int direction = 0;
    direction = Random.Range(0, 3);
    int[] targets = initializeTraget(random_x, random_y, direction);
    Debug.Log("random_x = " + random_x + " random_y = " + random_y + " direction" + direction +" targets[0] = " + targets[0] + " targets[1] = " + targets[1]);
    if (targets[0] <= 0 | targets[0] >= mapArray.Length - 2 | targets[1] <= 0 | targets[1] >= mapArray[targets[0]].Length - 2)
    {
      Debug.Log("29だ殺せ");
      //direction = getDirection(mapArray, random_x, random_y);
    }
    return direction;
  }

 //移動する向きを変える
  int changeDirection(int direction)
  {
    direction++;
    if (direction >= 4)
    {
      direction = 0;
    }
    return direction;
  }

  //targetの初期化する
  int[] initializeTraget(int random_x, int random_y, int direction)
  {
    int[] target_init = new int[2] { 0, 0 };
    if (direction == 0)
    {
      target_init[1] = random_x;
      target_init[0] = random_y + 1;
    }
    else if (direction == 1)
    {
      target_init[1] = random_x + 1;
      target_init[0] = random_y;
    }
    else if (direction == 2)
    {
      target_init[1] = random_x;
      target_init[0] = random_y - 1;
    }
    else if (direction == 3)
    {
      target_init[1] = random_x - 1;
      target_init[0] = random_y;
    }
    return target_init;
  }

  int[] getRandoms(int[][] mapArray)
  {
    int[] randoms = new int[] { 0, 0 };
    randoms[0] = Random.Range(1, 29);
    randoms[1] = Random.Range(1, 29);
    while(mapArray[randoms[0]][randoms[1]] == 0)
    {
      randoms[0] = Random.Range(1, 29);
      randoms[1] = Random.Range(1, 29);
    }
      return randoms;
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
