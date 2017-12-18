using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choose_test : MonoBehaviour
{   //掛載物件:Allfunstion
    //調用物件:leftbtn、rightbtn、confirm
	//說明:存放副程式以方便Button調用與維護
    public int index = 0;
    private Object[] sps;
    public GameObject pict;
    public static string SceneName = "map_1_1";//初值
    void Start()
    {
        sps = Resources.LoadAll("simplemap", typeof(Sprite));
        print (sps.Length);

    }
    public void cho_lv()
    {//之後做成直接更改圖片
        Sprite sp = (Sprite)sps[index];
        pict.transform.GetComponent<SpriteRenderer>().sprite = sp;
        print (sp.name);
    }
    public void gotoLv()//跳轉至SceneName畫面，依照SceneName內存字串而有所不同
    {
        SceneManager.LoadScene(SceneName);
    }
    public void pls()
    {
		if (index >= 0 && index < sps.Length-1){
            index++;
            cho_lv();
        }
       
    }
    public void dle()
    {
		if (index >= 1 && index <= sps.Length){
            index--;
            cho_lv();
        }
        
    }
}
