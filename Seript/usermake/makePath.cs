using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makePath : MonoBehaviour {
	public GameObject path;
	public int x,y;
	void Start() {
		path = GameObject.Find("path");
	}
	void OnMouseDown()
	{
		gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		gameObject.transform.parent = path.transform;
		print("x:"+x+"y:"+y);
	}
}
