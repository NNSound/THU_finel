using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour {
	//調用物件:12stars
	//說明:將子物件反覆設定可見、不可見以達成閃爍動畫之目的
	private IEnumerator coroutine;
	int i=1;//計數器
	// Use this for initialization
	void Start () {
		coroutine = Flashing(0.5f);//每隔0.5秒執行一次
        StartCoroutine(coroutine);
	}	
	// Update is called once per frame

	public IEnumerator Flashing(float waitTime){
		while(true) {//取得下一個節點物件
			transform.GetChild((i-1)%12).gameObject.SetActive(false);//將前一個物件設為不可見			
			transform.GetChild(i%12).gameObject.SetActive(true);//將本次的物件視為可見
			i++;
			yield return new WaitForSeconds(waitTime);
		}
	}
}
