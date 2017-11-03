using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choose_menu : MonoBehaviour
{

    //選擇場景 我想把它直接做成一隻靈活的腳本 不需要一個場景就一隻腳本
    void OnMouseUp()
    {
        SceneManager.LoadScene("menu");
    }
    void OnMouseEnter()
    {
        this.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 1);
    }
    void OnMouseExit()
    {
        this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }
}
