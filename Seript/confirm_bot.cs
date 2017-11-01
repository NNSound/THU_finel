using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class confirm_bot : MonoBehaviour {
    //選擇場景 我想把它直接做成一隻靈活的腳本 不需要一個場景就一隻腳本
    public static int  lv_counter = 28;
    public GameObject pict1,pict2,pict3;

    public static string SceneName = "map_1_1";
    void Start () {
		
	}
	void Update () {
		
	}
    void OnMouseUp()
    {        
        SceneManager.LoadScene(SceneName);
        
    }
    public void cho_level(){
        if (lv_counter % 3 ==1)
        {            
            pict1.gameObject.SetActive(true);
            pict2.gameObject.SetActive(false);
            pict3.gameObject.SetActive(false);
            SceneName = "map_1_1";
        }
        if (confirm_bot.lv_counter % 3 ==2)
        {            
            pict1.gameObject.SetActive(false);
            pict2.gameObject.SetActive(true);
            pict3.gameObject.SetActive(false);            
            SceneName = "map_1_2";
        }
        if (confirm_bot.lv_counter % 3 ==0)
        {            
            pict1.gameObject.SetActive(false);
            pict2.gameObject.SetActive(false);
            pict3.gameObject.SetActive(true);            
            SceneName = "map_1_3";
        }
    }
}
