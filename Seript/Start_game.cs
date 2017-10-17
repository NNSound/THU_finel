using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_game : MonoBehaviour {

    public GameObject cover;
    public GameObject left;
    public GameObject right;
    public GameObject confirm_bot;
    public GameObject lv1;
    //public GameObject lv2;
    public GameObject lv3;

    void Start () {

}
	void Update () {
		
	}
	void OnMouseUp()
 	{
        Destroy(gameObject);
        Destroy(cover);

        Vector3 left_bot_pos = new Vector3(-5, 0, 0);
        Vector3 right_bot_pos = new Vector3(5, 0, 0);
        Vector3 confirm_bot_pos = new Vector3(0, -3, 0);
        Vector3 lv_pos = new Vector3(0, 1, 0);

        Instantiate(left, left_bot_pos, transform.rotation);
        Instantiate(right, right_bot_pos, transform.rotation);
        Instantiate(confirm_bot, confirm_bot_pos, transform.rotation);
        Instantiate(lv1, lv_pos, transform.rotation);       
        //print("it work");
    }
    void OnMouseEnter()
    {
        this.gameObject.transform.localScale = new Vector3(2, 2, 1);
    }
    void OnMouseExit()
    {
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
 
/*
Vector3 mouse = Input.mousePosition;//滑鼠位置 (在螢幕的位置)
mouse.z = MainCameraControler.distance;//攝影機深度
Vector3 newPos = Camera.main.ScreenToWorldPoint(mouse);//畫面座標->世界座標
*/