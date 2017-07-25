using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_emeny : MonoBehaviour {
    public GameObject Emeny; //宣告物件，名稱Emeny
    public float time; //宣告浮點數，名稱time
                       // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime; //時間增加
        if (time > 1f) //如果時間大於1(秒)
        {
            Vector3 pos = new Vector3(-6f, 0, 0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
            Instantiate(Emeny, pos, transform.rotation); //產生敵人
            time = 0f; //時間歸零
        }
    }
}
