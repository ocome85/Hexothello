using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OthelloUI : MonoBehaviour
{
    GameObject[] EmpScore;
    GameObject[] BlkScore;
    GameObject[] WhtScore;
    public Text Score;
    public Text EndText;
    public GameObject EndTextobj;
    public GameObject Endbtnobj;
    public GameObject Endpanel;

    // Start is called before the first frame update
    public void Scorecount()
    {
        //各マスの数をカウント
        EmpScore= GameObject.FindGameObjectsWithTag("EmptyHex");
        BlkScore= GameObject.FindGameObjectsWithTag("BlackScore");
        WhtScore= GameObject.FindGameObjectsWithTag("WhiteScore");
        Score.text = ("Remaining trout :"+ (EmpScore.Length -1) + "\nBlack Score :" +( BlkScore.Length-1) + "\nWhite Score :" + (WhtScore.Length-1));
        
        if (EmpScore.Length-1 ==0)
        {
            //ゲーム終了時に少し盤面を映した後終了処理を実行する
            endgame();
        }
    }
    public void endgame()
    {
        if (BlkScore.Length > WhtScore.Length )
        {
            EndText.text =("Game End\nWinner: Black");
        }
        else if (BlkScore.Length < WhtScore.Length)
        {
        EndText.text =("Game End\nWinner: White");
        }
        else 
        { 
        EndText.text =("Game End\neven");
        }
        EndTextobj.SetActive (true);
        Endbtnobj.SetActive (true); 
        Endpanel.SetActive (true); 
    }
    // Update is called once per frame
    void Update()
    {
        //画面外の素材分-1 残りのマスと各スコアの表示
        //Score.text = ("Remaining trout :"+ (EmpScore.Length -1) + "\nBlack Score :" +( BlkScore.Length-1) + "\nWhite Score :" + (WhtScore.Length-1));
    }
}
