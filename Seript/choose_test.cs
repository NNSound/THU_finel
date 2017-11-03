using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choose_test : MonoBehaviour
{
    public int i = 1;
    public GameObject pict1, pict2, pict3;
    public static string SceneName = "map_1_1";
    // Use this for initialization
    public void cho_lv()
    {//之後做成直接更改圖片
        if (i > 0 && i <= 3)
        {
            if (i % 3 == 1)
            {
                pict1.gameObject.SetActive(true);
                pict2.gameObject.SetActive(false);
                pict3.gameObject.SetActive(false);
                SceneName = "map_1_1";
            }
            if (i % 3 == 2)
            {
                pict1.gameObject.SetActive(false);
                pict2.gameObject.SetActive(true);
                pict3.gameObject.SetActive(false);
                SceneName = "map_1_2";
            }
            if (i % 3 == 0)
            {
                pict1.gameObject.SetActive(false);
                pict2.gameObject.SetActive(false);
                pict3.gameObject.SetActive(true);
                SceneName = "map_1_3";
            }
        }

    }
    public void gotoLv()
    {
        SceneManager.LoadScene(SceneName);
    }
    public void pls()
    {
        print ("somehappen");
		if (i > 0 && i < 3)
        i++;
        print(i);
    }
    public void dle()
    {
		if (i > 1 && i < 4)
        i--;
        print(i);
    }
}
