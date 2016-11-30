using UnityEngine;
using System.Collections;

public class ProvMap : MonoBehaviour {
 
  int[] defaultArray00 = new int[31] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
  int[] defaultArray01 = new int[31] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
  int[] defaultArray02 = new int[31] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
  int[] defaultArray03 = new int[31] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0 };
  int[] defaultArray04 = new int[31] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0 };
  int[] defaultArray05 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0 };
  int[] defaultArray06 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0 };
  int[] defaultArray07 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0 };
  int[] defaultArray08 = new int[31] { 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
  int[] defaultArray09 = new int[31] { 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
  int[] defaultArray10 = new int[31] { 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 };
  int[] defaultArray11 = new int[31] { 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0 };
  int[] defaultArray12 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0 };
  int[] defaultArray13 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 };
  int[] defaultArray14 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
  int[] defaultArray15 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0 };
  int[] defaultArray16 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
  int[] defaultArray17 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
  int[] defaultArray18 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
  int[] defaultArray19 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
  int[] defaultArray20 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
  int[] defaultArray21 = new int[31] { 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
  int[] defaultArray22 = new int[31] { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
  int[] defaultArray23 = new int[31] { 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
  int[] defaultArray24 = new int[31] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
  int[] defaultArray25 = new int[31] { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0 };
  int[] defaultArray26 = new int[31] { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0 };
  int[] defaultArray27 = new int[31] { 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0 };
  int[] defaultArray28 = new int[31] { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
  int[] defaultArray29 = new int[31] { 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 };
  int[] defaultArray30 = new int[31] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
  int[][] mapArray = new int[31][] ;
  void Awake()
  {
    int rand = Random.Range(0, 9);
    mapArray[0] = (int[])defaultArray00.Clone();
    mapArray[1] = (int[])defaultArray01.Clone();
    mapArray[2] = (int[])defaultArray02.Clone();
    mapArray[3] = (int[])defaultArray03.Clone();
    mapArray[4] = (int[])defaultArray04.Clone();
    mapArray[5] = (int[])defaultArray05.Clone();
    mapArray[6] = (int[])defaultArray06.Clone();
    mapArray[7] = (int[])defaultArray07.Clone();
    mapArray[8] = (int[])defaultArray08.Clone();
    mapArray[9] = (int[])defaultArray09.Clone();
    mapArray[10] = (int[])defaultArray10.Clone();
    mapArray[11] = (int[])defaultArray11.Clone();
    mapArray[12] = (int[])defaultArray12.Clone();
    mapArray[13] = (int[])defaultArray13.Clone();
    mapArray[14] = (int[])defaultArray14.Clone();
    mapArray[15] = (int[])defaultArray15.Clone();
    mapArray[16] = (int[])defaultArray16.Clone();
    mapArray[17] = (int[])defaultArray17.Clone();
    mapArray[18] = (int[])defaultArray18.Clone();
    mapArray[19] = (int[])defaultArray19.Clone();
    mapArray[20] = (int[])defaultArray20.Clone();
    mapArray[21] = (int[])defaultArray21.Clone();
    mapArray[22] = (int[])defaultArray22.Clone();
    mapArray[23] = (int[])defaultArray23.Clone();
    mapArray[24] = (int[])defaultArray24.Clone();
    mapArray[25] = (int[])defaultArray25.Clone();
    mapArray[26] = (int[])defaultArray26.Clone();
    mapArray[27] = (int[])defaultArray27.Clone();
    mapArray[28] = (int[])defaultArray28.Clone();
    mapArray[29] = (int[])defaultArray29.Clone();
    mapArray[30] = (int[])defaultArray30.Clone();

    switch(rand){
      case 0:
        mapArray[0][0] = 999;
        break;
      case 1:
        mapArray[30][0] = 999;
        break;
      case 2:
        mapArray[0][30] = 999;
        break;
      case 3:
        mapArray[30][30] = 999;
        break;
      case 4:
        mapArray[15][0] = 999;
        break;
      case 5:
        mapArray[0][15] = 999;
        break;
      case 6:
        mapArray[15][30] = 999;
        break;
      case 7:
        mapArray[30][15] = 999;
        break;
      case 8:
        mapArray[5][0] = 999;
        break;
      case 9:
        mapArray[0][25] = 999;
        break;
      default:
        mapArray[0][0] = 999;
        break;
    }
  }
  
  public int[][] getProvMap()
  {
    return mapArray;
  }

}
