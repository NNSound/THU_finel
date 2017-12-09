using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makePath : MonoBehaviour {
	public GameObject path;
	
	void Start() {
		path = GameObject.Find("path");
	}
	void OnMouseDown()
	{
		gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		var a = gameObject.GetComponent<floorInfo>();
		GameInfo.floors[a.x,a.y]=1;
		a.floorSet=1;
		if((a.x==0||a.x==15)||(a.y==0||a.y==8)){
			a.floorSet=9;
		}
		//if(GameInfo.floors[a.x,a.y]>1)
		//	gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		gameObject.transform.parent = path.transform;
	}
}
