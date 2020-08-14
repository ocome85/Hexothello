using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class OthelloStone : MonoBehaviour
{
public OthelloUI OthelloUI;
public Othello Othello;
int turnchk ;
int changeok=0;
int changeokk=0;
int chk1 ;
GameObject clickedGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    //白黒コマの情報を与える
    public void StoneChange(GameObject White , GameObject Black , GameObject Empty , GameObject Turn ,int stagelength)
    {
        int clickhex ;
        var list = new List<GameObject>();
        var listpos = new List<Vector3>();
        //GameObject cube = GameObject.Find("HexY"+1+"X"+1);
        list.Clear();
        listpos.Clear();
        turnchk=0;
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
            //Debug.Log(tmp);
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
            clickhex=1;
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
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag == Turn.tag)
                    {
                        //リスト内の相手の石を削除
                        for (int i = 0; i < list.Count; i++)
                            {
                                Destroy(list[i]);
                                GameObject newst = Instantiate (Turn, listpos[i], Quaternion.identity);  
                                newst.name=list[i].name;
                                //Debug.Log(list[i].name+"1");

                                if (clicktag == "EmptyHex" && clickhex == 1 )
                                {
                                    Destroy(clickedGameObject);
                                    GameObject newclst = Instantiate (Turn,tmp, Quaternion.identity);  
                                    newclst.name =Checkstone;
                                    turnchk=1;
                                    clickhex =0;
                                }

                            }
                        goto a;
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
                    //Debug.Log("上方向処理完了");
                    break;
                }
            }
            a:
            list.Clear();
            listpos.Clear();

            int dwstrValue1I = strValue1I;
            for (int y=stagelength-1; y>= dwstrValue1I;)
            {
                dwstrValue1I ++;
                GameObject chkhex= GameObject.Find("HexY" + strValueI + "X" + dwstrValue1I);
                string chkhexst= ("HexY" + strValueI + "X" + dwstrValue1I);
                //Debug.Log("HexY" + strValueI + "X" + dwstrValue1I);
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag == Turn.tag)
                    {
                        //リスト内の相手の石を削除
                        for (int i = 0; i < list.Count; i++)
                            {
                                Destroy(list[i]);
                                GameObject newst = Instantiate (Turn, listpos[i], Quaternion.identity);  
                                newst.name=list[i].name;
                                //Debug.Log(list[i].name+("2"));

                                if (clicktag == "EmptyHex" && clickhex == 1 )
                                {
                                    Destroy(clickedGameObject);
                                    GameObject newclst = Instantiate (Turn,tmp, Quaternion.identity);  
                                    newclst.name =Checkstone;
                                    turnchk=1;
                                    clickhex =0;
                                }

                            }
                            goto a1;
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
                    //Debug.Log("下方向処理完了");
                    break;
                }
            }
            a1:
            list.Clear();
            listpos.Clear();
            int rdstrValue1I = strValue1I; //y
            int rdstrValueI = strValueI;  //x
            for (int y=stagelength; y>= rdstrValue1I && y>= rdstrValueI;)
            {
                rdstrValueI ++ ;
                if (rdstrValueI % 2 ==0)
                {
                    rdstrValue1I ++;
                }

                GameObject chkhex= GameObject.Find("HexY" + rdstrValueI + "X" + rdstrValue1I);
                //Debug.Log(("HexY" + rdstrValueI + "X" + rdstrValue1I));
                string chkhexst= ("HexY" + rdstrValueI + "X" + rdstrValue1I);
                try
                {
                Vector3 dhkhexpos=chkhex.transform.position;
                }
                catch (NullReferenceException)
                {
                break;
                }
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag == Turn.tag)
                    {
                        //リスト内の相手の石を削除
                        for (int i = 0; i < list.Count; i++)
                            {
                                Destroy(list[i]);
                                GameObject newst = Instantiate (Turn, listpos[i], Quaternion.identity);  
                                newst.name=list[i].name;
                                //Debug.Log(list[i].name+ ("3"));

                                if (clicktag == "EmptyHex" && clickhex == 1 )
                                {
                                    Destroy(clickedGameObject);
                                    GameObject newclst = Instantiate (Turn,tmp, Quaternion.identity);  
                                    newclst.name =Checkstone;
                                    turnchk=1;
                                    clickhex =0;
                                }

                            }
                        goto a2;
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
                    break;
                }
            }
            a2:
        list.Clear();
        listpos.Clear();
        int rustrValue1I = strValue1I; //y
        int rustrValueI = strValueI;  //x
        for (int y=stagelength; 2<= rustrValue1I && y>= rustrValueI;)
            {
                rustrValueI ++ ;
                if (rustrValueI % 2 !=0)
                {
                    rustrValue1I --;
                }

                GameObject chkhex= GameObject.Find("HexY" + rustrValueI + "X" + rustrValue1I);
                //Debug.Log(("HexY" + rustrValueI + "X" + rustrValue1I));
                string chkhexst= ("HexY" + rustrValueI + "X" + rustrValue1I);
                try
                {
                Vector3 dhkhexpos=chkhex.transform.position;
                }
                catch (NullReferenceException)
                {
                break;
                }
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag == Turn.tag)
                    {
                        //リスト内の相手の石を削除
                        for (int i = 0; i < list.Count; i++)
                            {
                                Destroy(list[i]);
                                GameObject newst = Instantiate (Turn, listpos[i], Quaternion.identity);  
                                newst.name=list[i].name;
                                //Debug.Log(list[i].name+ ("3"));

                                if (clicktag == "EmptyHex" && clickhex == 1 )
                                {
                                    Destroy(clickedGameObject);
                                    GameObject newclst = Instantiate (Turn,tmp, Quaternion.identity);  
                                    newclst.name =Checkstone;
                                    turnchk=1;
                                    clickhex =0;
                                }

                            }
                        goto a3;
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
                    break;
                }
            }
            a3:
        list.Clear();
        listpos.Clear();
        int lustrValue1I = strValue1I; //y
        int lustrValueI = strValueI;  //x
        for (;2<= lustrValue1I && 2<= lustrValueI;)
            {
                lustrValueI -- ;
                if (lustrValueI % 2 !=0)
                {
                    lustrValue1I --;
                }

                GameObject chkhex= GameObject.Find("HexY" + lustrValueI + "X" + lustrValue1I);
                //Debug.Log(("HexY" + lustrValueI + "X" + lustrValue1I));
                string chkhexst= ("HexY" + lustrValueI + "X" + lustrValue1I);
                try
                {
                Vector3 dhkhexpos=chkhex.transform.position;
                }
                catch (NullReferenceException)
                {
                break;
                }
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag == Turn.tag)
                    {
                        //リスト内の相手の石を削除
                        for (int i = 0; i < list.Count; i++)
                            {
                                Destroy(list[i]);
                                GameObject newst = Instantiate (Turn, listpos[i], Quaternion.identity);  
                                newst.name=list[i].name;
                                //Debug.Log(list[i].name+ ("3"));

                                if (clicktag == "EmptyHex" && clickhex == 1 )
                                {
                                    Destroy(clickedGameObject);
                                    GameObject newclst = Instantiate (Turn,tmp, Quaternion.identity);  
                                    newclst.name =Checkstone;
                                    turnchk=1;
                                    clickhex =0;
                                }

                            }
                        goto a4;
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
                    break;
                }
            }
            a4:
        list.Clear();
        listpos.Clear();

        int ldstrValue1I = strValue1I; //y
        int ldstrValueI = strValueI;  //x
        for (int y=stagelength; 1<= ldstrValue1I && y>= ldstrValueI;)
            {
                ldstrValueI -- ;
                if (ldstrValueI % 2 ==0)                {
                    ldstrValue1I ++;
                }

                GameObject chkhex= GameObject.Find("HexY" + ldstrValueI + "X" + ldstrValue1I);
                //Debug.Log(("HexY" + ldstrValueI + "X" + ldstrValue1I));
                string chkhexst= ("HexY" + ldstrValueI + "X" + ldstrValue1I);
                try
                {
                Vector3 dhkhexpos=chkhex.transform.position;
                }
                catch (NullReferenceException)
                {
                break;
                }
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag == Turn.tag)
                    {
                        //リスト内の相手の石を削除
                        for (int i = 0; i < list.Count; i++)
                            {
                                Destroy(list[i]);
                                GameObject newst = Instantiate (Turn, listpos[i], Quaternion.identity);  
                                newst.name=list[i].name;
                                //Debug.Log(list[i].name+ ("3"));

                                if (clicktag == "EmptyHex" && clickhex == 1 )
                                {
                                    Destroy(clickedGameObject);
                                    GameObject newclst = Instantiate (Turn,tmp, Quaternion.identity);  
                                    newclst.name =Checkstone;
                                    turnchk=1;
                                    clickhex =0;
                                }

                            }
                        goto a5;
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
                    break;
                }
            }
            a5:
        list.Clear();
        listpos.Clear();
        }


        
        if (turnchk ==1)
        {
        Othello.Turnchange1();
        }

    }


    public void changechk(GameObject Turn ,int stagelength,int kaisuu)
    {
        changeokk =0;
        GameObject[] Emp;
        Emp= GameObject.FindGameObjectsWithTag("EmptyHex");
        for (int yy =1;Emp.Length >yy;) 
        {
        chk1++;
        Vector3 tmp = Emp[yy].transform.position;
            //Debug.Log(tmp);
        string clicktag  =Emp[yy].tag;
        var list = new List<GameObject>();
        var listpos = new List<Vector3>();
        //GameObject cube = GameObject.Find("HexY"+1+"X"+1);
        list.Clear();
        listpos.Clear();
        changeok =0;
        turnchk=0;
        string Checkstone=Emp[yy].name;

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
            // Y軸
            //Debug.Log(strValue1I);
            // 上下を返せるかの判定
            //上方向の処理　y軸の元の値を変えない為 up** とする
            int upstrValue1I = strValue1I;
            chk1 =0;
            for (int y=2; y<= upstrValue1I;)
            {
                chk1 ++;
                upstrValue1I --;
                GameObject chkhex= GameObject.Find("HexY" + strValueI + "X" + upstrValue1I);
                string chkhexst= ("HexY" + strValueI + "X" + upstrValue1I);
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag != Turn.tag)
                    {
                        if (changeok ==1)
                        {
                            Debug.Log(Emp[yy].name+"ue"+kaisuu);
                            changeokk =1;
                        }
                        if(chk1 ==1)
                        {
                            break;
                        }
                    }
                    //違う場合
                    else
                    {
                        changeok=1;
                    }
                }
                else 
                //空白石の場合はその時点で、終了
                {
                    //Debug.Log("上方向処理完了");
                    break;
                }
            }
            list.Clear();
            listpos.Clear();
            changeok =0;
            chk1 =0;
            int dwstrValue1I = strValue1I;
            for (int y=stagelength-1; y>= dwstrValue1I;)
            {
                chk1++;
                dwstrValue1I ++;
                GameObject chkhex= GameObject.Find("HexY" + strValueI + "X" + dwstrValue1I);
                string chkhexst= ("HexY" + strValueI + "X" + dwstrValue1I);
                //Debug.Log("HexY" + strValueI + "X" + dwstrValue1I);
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag != Turn.tag)
                    {
                        if (changeok ==2)
                        {
                            Debug.Log(Emp[yy].name+"sita"+kaisuu);
                            changeokk =1;
                        }
                        if(chk1 ==1)
                        {
                            break;
                        }
                    }
                    //違う場合
                    else
                    {
                        changeok=2;
                    }
                }
                else 
                //空白石の場合はその時点で、終了
                {
                    //Debug.Log("下方向処理完了");
                    break;
                }
            }
            list.Clear();
            listpos.Clear();
            changeok =0;
            chk1=0;
            int rdstrValue1I = strValue1I; //y
            int rdstrValueI = strValueI;  //x
            for (int y=stagelength; y>= rdstrValue1I && y>= rdstrValueI;)
            {
                chk1++;
                rdstrValueI ++ ;
                if (rdstrValueI % 2 ==0)
                {
                    rdstrValue1I ++;
                }

                GameObject chkhex= GameObject.Find("HexY" + rdstrValueI + "X" + rdstrValue1I);
                //Debug.Log(("HexY" + rdstrValueI + "X" + rdstrValue1I));
                string chkhexst= ("HexY" + rdstrValueI + "X" + rdstrValue1I);
                try
                {
                Vector3 dhkhexpos=chkhex.transform.position;
                }
                catch (NullReferenceException)
                {
                break;
                }
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag != Turn.tag)
                    {
                        if (changeok ==3)
                        {
                            Debug.Log(Emp[yy].name+"migisita"+kaisuu);
                            changeokk =1;
                        }
                        if(chk1 ==1)
                        {
                            break;
                        }
                    }
                    //違う場合
                    else
                    {
                        changeok=3;
                    }
                }
                else 
                //空白石の場合はその時点で、終了
                {
                    break;
                }
            }
        list.Clear();
        listpos.Clear();
        changeok =0;
        chk1=0;
        int rustrValue1I = strValue1I; //y
        int rustrValueI = strValueI;  //x
        for (int y=stagelength; 2<= rustrValue1I && y>= rustrValueI;)
            {
                chk1++;
                rustrValueI ++ ;
                if (rustrValueI % 2 !=0)
                {
                    rustrValue1I --;
                }

                GameObject chkhex= GameObject.Find("HexY" + rustrValueI + "X" + rustrValue1I);
                //Debug.Log(("HexY" + rustrValueI + "X" + rustrValue1I));
                string chkhexst= ("HexY" + rustrValueI + "X" + rustrValue1I);
                try
                {
                Vector3 dhkhexpos=chkhex.transform.position;
                }
                catch (NullReferenceException)
                {
                break;
                }
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag != Turn.tag)
                    {
                        if (changeok ==4)
                        {
                            Debug.Log(Emp[yy].name+"migiue" +kaisuu);
                            changeokk =1;
                        }
                        if(chk1 ==1)
                        {
                            break;
                        }
                    }
                    //違う場合
                    else
                    {
                       changeok=4;
                    }
                }
                else 
                //空白石の場合はその時点で、終了
                {
                    break;
                }
            }
        list.Clear();
        listpos.Clear();
        changeok =0;
        chk1=0;
        int lustrValue1I = strValue1I; //y
        int lustrValueI = strValueI;  //x
        for (;2<= lustrValue1I && 2<= lustrValueI;)
            {
                chk1++;
                lustrValueI -- ;
                if (lustrValueI % 2 !=0)
                {
                    lustrValue1I --;
                }

                GameObject chkhex= GameObject.Find("HexY" + lustrValueI + "X" + lustrValue1I);
                //Debug.Log(("HexY" + lustrValueI + "X" + lustrValue1I));
                string chkhexst= ("HexY" + lustrValueI + "X" + lustrValue1I);
                try
                {
                Vector3 dhkhexpos=chkhex.transform.position;
                }
                catch (NullReferenceException)
                {
                break;
                }
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag != Turn.tag)
                    {
                        if (changeok ==5)
                        {
                            Debug.Log(Emp[yy].name+"hidariue"+kaisuu);
                            changeokk =1;
                        }
                        if(chk1 ==1)
                        {
                            break;
                        }
                    }
                    //違う場合
                    else
                    {
                        //listへ変更される石として保存
                        changeok=5;
                    }
                }
                else 
                //空白石の場合はその時点で、終了
                {
                    break;
                }
            }
        list.Clear();
        listpos.Clear();
        changeok =0;
        chk1=0;
        int ldstrValue1I = strValue1I; //y
        int ldstrValueI = strValueI;  //x
        for (int y=stagelength; 1<= ldstrValue1I && y>= ldstrValueI;)
            {
                chk1++;
                ldstrValueI -- ;
                if (ldstrValueI % 2 ==0)                {
                    ldstrValue1I ++;
                }

                GameObject chkhex= GameObject.Find("HexY" + ldstrValueI + "X" + ldstrValue1I);
                //Debug.Log(("HexY" + ldstrValueI + "X" + ldstrValue1I));
                string chkhexst= ("HexY" + ldstrValueI + "X" + ldstrValue1I);
                try
                {
                Vector3 dhkhexpos=chkhex.transform.position;
                }
                catch (NullReferenceException)
                {
                break;
                }
                Vector3 chkhexpos=chkhex.transform.position;
                string targetHex = chkhex.tag;
                //Debug.Log(chkhex.tag);
                //石がおかれている場合
                if (targetHex != "EmptyHex" && clicktag =="EmptyHex")
                {
                    //その石がターン中の石の場合
                    if (chkhex.tag != Turn.tag)
                    {
                        if (changeok ==6)
                        {
                            Debug.Log(Emp[yy].name+"hidarisita"+kaisuu);
                            changeokk =1;
                        }
                        if(chk1 ==1)
                        {
                            break;
                        }
                    }
                    //違う場合
                    else
                    {
                        changeok =6;
                    }
                }
                else 
                //空白石の場合はその時点で、終了
                {
                    break;
                }
            }
        yy++;
        changeok =0;
        }
        Debug.Log(changeokk );
        if (changeokk ==0)
        {
            if (kaisuu ==1)
            {
                //Debug.Log("到達1");
                OthelloUI.endgame();
            }
            else
            {
                Debug.Log("置く場所がありません");
                Othello.Turnchange();
            }

        }
        
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