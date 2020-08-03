using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class OthelloStone : MonoBehaviour
{

GameObject clickedGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    //白黒コマの情報を与える
    public void StoneChange(GameObject White , GameObject Black , GameObject Empty , GameObject Turn ,int stagelength)
    {
        //GameObject cube = GameObject.Find("HexY"+1+"X"+1);

 
        if (Input.GetMouseButtonDown(0)) {

            /*石がクリックされた事を検知
            以下サンプル
            if (Input.GetMouseButtonDown(0)) {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit)) {
                clickedGameObject = hit.collider.gameObject;
            }

            Debug.Log(clickedGameObject);
            */
 
            clickedGameObject = null;
 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();



            if (Physics.Raycast(ray, out hit)) {
                clickedGameObject = hit.collider.gameObject;
            }
 
            //Debug.Log(clickedGameObject);
            //クリックした石の座標を取得
            //Vector3 tmp = GameObject.Find("HexY"+1+"X"+1).transform.position;
            Vector3 tmp = clickedGameObject.transform.position;
            Debug.Log(tmp);
            string clicktag =clickedGameObject.tag;

            //クリックした石の名前を取得
            string Checkstone=clickedGameObject.name;

            //オブジェクト名からY座標とX座標の値を取得
            string strValue = Checkstone.Remove(0,Checkstone.IndexOf("Y"));
            strValue = strValue.Remove(strValue.IndexOf("X"));
            string strValueA = strValue.Replace("Y", "");
            int strValueI = int.Parse(strValueA);
            //X軸
            //Debug.Log(strValueI);

            string strValue1 = Checkstone.Remove(0,Checkstone.IndexOf("X"));
            string strValue1A = strValue1.Replace("X", "");
            int strValue1I = int.Parse(strValue1A);

            var list = new List<GameObject>();
            var listpos = new List<Vector3>();
            // Y軸
            //Debug.Log(strValue1I);
            // 上下を返せるかの判定
            //上方向の処理　y軸の元の値を変えない為 up** とする
            int upstrValue1I = strValue1I;
            for (int y=2; y<= upstrValue1I;)
            {
                upstrValue1I --;
                GameObject chkhex= GameObject.Find("HexY" + strValueI + "X" + upstrValue1I);
                string chkhexst= ("HexY" + strValueI + "X" + upstrValue1I);
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex")
                {
                    //その石がターン中の石の場合
                    Debug.Log(chkhex.tag + Turn.tag);
                    if (chkhex.tag == Turn.tag)
                    {
                        //リスト内の相手の石を削除
                        for (int i = 0; i < list.Count; i++)
                            {
                                Destroy(list[i]);
                                GameObject newst = Instantiate (Turn, listpos[i], Quaternion.identity);  
                                newst.name=list[i].name;
                                //Debug.Log(list[i].name);

                                if (clicktag == "EmptyHex")
                                {
                                    Destroy(clickedGameObject);
                                    GameObject newclst = Instantiate (Turn,tmp, Quaternion.identity);  
                                    newclst.name =Checkstone;
                                }

                            }
                        list.Clear();
                        listpos.Clear();
                    }
                    //違う場合
                    else
                    {
                        //listへ変更される石として保存
                        list.Add(chkhex);
                        //listposへ変更される際の場所指定として保存
                        listpos.Add(chkhexpos);
                    }
                }
                else 
                //空白石の場合はその時点で、終了
                {
                    Debug.Log("上方向処理完了");
                    break;
                }
            }

            int dwstrValue1I = strValue1I;
            for (int y=stagelength+1; y>= dwstrValue1I;)
            {
                dwstrValue1I ++;
                GameObject chkhex= GameObject.Find("HexY" + strValueI + "X" + dwstrValue1I);
                string chkhexst= ("HexY" + strValueI + "X" + dwstrValue1I);
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex")
                {
                    //その石がターン中の石の場合
                    Debug.Log(chkhex.tag + Turn.tag);
                    if (chkhex.tag == Turn.tag)
                    {
                        //リスト内の相手の石を削除
                        for (int i = 0; i < list.Count; i++)
                            {
                                Destroy(list[i]);
                                GameObject newst = Instantiate (Turn, listpos[i], Quaternion.identity);  
                                newst.name=list[i].name;
                                //Debug.Log(list[i].name);

                                if (clicktag == "EmptyHex")
                                {
                                    Destroy(clickedGameObject);
                                    GameObject newclst = Instantiate (Turn,tmp, Quaternion.identity);  
                                    newclst.name =Checkstone;
                                }

                            }
                        list.Clear();
                        listpos.Clear();
                    }
                    //違う場合
                    else
                    {
                        //listへ変更される石として保存
                        list.Add(chkhex);
                        //listposへ変更される際の場所指定として保存
                        listpos.Add(chkhexpos);
                    }
                }
                else 
                //空白石の場合はその時点で、終了
                {
                    Debug.Log("下方向処理完了");
                    break;
                }
            }

            //石の色を変える場合元の石を削除する
            

　
        }
    

    }

//GameObjectUtils.DestoryIfExist( ***); 名称***のobujectを削除する
public static class GameObjectUtils
{
    public static void DestoryIfExist( string name )
    {
        var gameObject = GameObject.Find( name );
        if ( gameObject == null )
        {
            return;
        }
        GameObject.Destroy( gameObject );
    }
}
}
