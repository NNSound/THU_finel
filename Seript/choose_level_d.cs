using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose_level_d : MonoBehaviour
{
    //套用物件 : left_bot、right_bot
    //簡短說明 : 左右選擇關卡，當滑鼠移動到物件上時放大物件
    public confirm_bot bot;
    public GameObject pict1,pict2,pict3;
    void OnMouseUp()
    {
        confirm_bot.lv_counter--;
        //bot = gameObject.GetComponent<confirm_bot>();
        //bot.cho_level();
        if (confirm_bot.lv_counter % 3 ==1)
        {            
            pict1.gameObject.SetActive(true);
            pict2.gameObject.SetActive(false);
            pict3.gameObject.SetActive(false);
            confirm_bot.SceneName = "map_1_1";
        }
        if (confirm_bot.lv_counter % 3 ==2)
        {            
            pict1.gameObject.SetActive(false);
            pict2.gameObject.SetActive(true);
            pict3.gameObject.SetActive(false);            
            confirm_bot.SceneName = "map_1_2";
        }
        if (confirm_bot.lv_counter % 3 ==0)
        {            
            pict1.gameObject.SetActive(false);
            pict2.gameObject.SetActive(false);
            pict3.gameObject.SetActive(true);            
            confirm_bot.SceneName = "map_1_3";
        }

    }
    void OnMouseEnter()
    {
        this.transform.localScale = new Vector3(2, 2, 1);
    }
    void OnMouseExit()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
    }
}
