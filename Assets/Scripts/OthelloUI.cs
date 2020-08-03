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
    // Start is called before the first frame update
    public void Scorecount()
    {
        //各マスの数をカウント
        EmpScore= GameObject.FindGameObjectsWithTag("EmptyHex");
        BlkScore= GameObject.FindGameObjectsWithTag("BlackScore");
        WhtScore= GameObject.FindGameObjectsWithTag("WhiteScore");
        Score.text = ("Remaining trout :"+ (EmpScore.Length -1) + "\nBlack Score :" +( BlkScore.Length-1) + "\nWhite Score :" + (WhtScore.Length-1));
    }

    // Update is called once per frame
    void Update()
    {
        //画面外の素材分-1 残りのマスと各スコアの表示
        //Score.text = ("Remaining trout :"+ (EmpScore.Length -1) + "\nBlack Score :" +( BlkScore.Length-1) + "\nWhite Score :" + (WhtScore.Length-1));
    }
}
