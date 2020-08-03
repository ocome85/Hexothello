using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Othello : MonoBehaviour
{

    public GameObject White;
    public GameObject Black;
    //操作プレイヤー
    public GameObject TargetStone;
    public GameObject Turn;

    //生成フィールドの長さ
    public int stagelength ;
    
    public GameObject EmptyHex;
    GameObject TargetHex;
    public OthelloUI OthelloUI;
    public OthelloStone OthelloStone;
    int tateretu;
    int yokoretu;
    bool chk;

    string Hexname;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate (Black, new Vector3 (0f, 0, 3.468f), Quaternion.identity);
        for (int y=1; y<= stagelength;)
        {
            for (int x=1; x<=stagelength;)
                {
                if (y==stagelength/2 | y==stagelength/2+1 && x==stagelength/2 |x==stagelength/2+1)
                    {
                        if (chk==false)
                        {
                        chk=true;
                        TargetHex = White;
                        }
                        else
                        {
                        chk=false;
                        TargetHex=Black;
                        }
                    }
                else 
                    { 
                        TargetHex =EmptyHex;
                    }
                    if (y%2 ==0)
                    {
                        //開始の空きマス作成
                        GameObject NewHex=Instantiate (TargetHex, new Vector3 (x*1.1f, -1, y*1f), Quaternion.identity);  
                        Hexname="HexY"+y+"X"+x;
                        NewHex.name=Hexname;
                    }
                    else 
                    {
                        //2×2のマス作成
                        GameObject NewHex=Instantiate (TargetHex, new Vector3 (x*1.1f+0.5f, -1, y*1f), Quaternion.identity);  
                        Hexname="HexY"+y+"X"+x;
                        NewHex.name=Hexname;
                        
                    }
                    //a[0].Add(Hexname,"s");
                    x ++;
                    //Debug.Log(a);
                    //Debug.Log(list[y][0]);
                }
                y ++;

            OthelloUI.Scorecount();
        }
        /*
        Instantiate (Black, new Vector3 (4f, 0, 3.468f), Quaternion.identity);
        Instantiate (White, new Vector3 (5f, 0, 3.468f), Quaternion.identity);
        Instantiate (White, new Vector3 (4.5f, 0, 4.335f), Quaternion.identity);
        Instantiate (Black, new Vector3 (5.5f, 0, 4.335f), Quaternion.identity);
        */  
    }

    public void botan ()
    {
        Debug.Log("クリックされました");
        OthelloStone.StoneChange(White,Black,EmptyHex,Turn,stagelength); 
        OthelloUI.Scorecount();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
