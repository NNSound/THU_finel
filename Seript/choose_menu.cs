using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choose_menu : MonoBehaviour
{//調用物件:Start_obj
    //選擇場景
    void OnMouseUp()
    {
        SceneManager.LoadScene("menu");//移動到menu場景
    }
    void OnMouseEnter()//滑鼠移動到上面時，放大
    {
        this.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 1);
    }
    void OnMouseExit()//滑鼠移動到上面時，回復原樣
    {
        this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }
}
