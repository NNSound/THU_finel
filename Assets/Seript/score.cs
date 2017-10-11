using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text ScoreText; //宣告一個ScoreText的text
    public static int Callgame_HP = 100; // 宣告一整數 Score
    public static score Instance; // 設定Instance，讓其他程式能讀取end裡的東西

    public GameObject Image;//宣告Image物件
    // Use this for initialization
    void Start()
    {
        Instance = this; //指定Instance這個程式
        Image.SetActive(false); ; //設定Image不顯示(打勾取消)
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore()//wall 呼叫
    {
        Callgame_HP -= 10; //分數-10
        ScoreText.text = "HP: " + Callgame_HP;  // 更改ScoreText的內容
        if(Callgame_HP == 0)
        { 
            Image.SetActive(true); //Image設定為ture          
          //  wall.SetActive(false); //設定wall不顯示(打勾取消)           
        }

    }
}
