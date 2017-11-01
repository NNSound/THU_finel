using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour {
	private IEnumerator coroutine;
	int i=1;
	// Use this for initialization
	void Start () {
		coroutine = Flashing(0.5f);
        StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
	}
	public IEnumerator Flashing(float waitTime){
		while(true) {//取得下一個節點物件
			transform.GetChild((i-1)%12).gameObject.SetActive(false);			
			transform.GetChild(i%12).gameObject.SetActive(true);
			i++;
			yield return new WaitForSeconds(waitTime);
		}
	}
}
