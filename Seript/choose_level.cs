using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose_level : MonoBehaviour {
//套用物件 : left_bot、right_bot
//簡短說明 : 左右選擇關卡，當滑鼠移動到物件上時放大物件
    public static float lv_counter=1;
    public GameObject pict1,pict2,pict3;
    void Start () {
		
	}
	void Update () {
		
	}
    void OnMouseUp()
    {            
        //Debug.Log(lv_counter);//所以左右件都是擺好看的喔? 
        lv_counter++;
        if (lv_counter % 3 ==1)
        {            
            pict1.gameObject.SetActive(true);
            pict2.gameObject.SetActive(false);
            pict3.gameObject.SetActive(false);
        }
        if (lv_counter % 3 ==2)
        {            
            pict1.gameObject.SetActive(false);
            pict2.gameObject.SetActive(true);
            pict3.gameObject.SetActive(false);
        }
        if (lv_counter % 3 ==0)
        {            
            pict1.gameObject.SetActive(false);
            pict2.gameObject.SetActive(false);
            pict3.gameObject.SetActive(true);
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
