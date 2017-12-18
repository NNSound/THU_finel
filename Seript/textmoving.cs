using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textmoving : MonoBehaviour {
	public Button skip;
	public GameObject menu;
	void Update () {
		if(gameObject.transform.position.y>10)
			skipbtn();
		else
			gameObject.transform.position += new Vector3(0,0.01f,0);
		if(gameObject.transform.position.y>0)
			skip.gameObject.SetActive(true);
	}
	public void skipbtn(){
		Destroy(gameObject.transform.parent.gameObject);
		menu.SetActive(true);
	}
}
