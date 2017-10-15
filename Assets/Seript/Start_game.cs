using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_game : MonoBehaviour {
    public GameObject map;
	public GameObject wall;
	public GameObject cover;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseUp()
 	{
		Vector3 map_tr =new Vector3 (0,0,0);
		Vector3 wall_tr =new Vector3 (6,0,0);
		Instantiate(map,map_tr , transform.rotation);
		Instantiate(wall,wall_tr , transform.rotation);
        Destroy(gameObject);
        Destroy(cover);
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