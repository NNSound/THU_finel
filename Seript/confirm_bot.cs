using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class confirm_bot : MonoBehaviour {
    //public GameObject left_bot;
    //public GameObject right_bot;
    void Start () {
		
	}
	void Update () {
		
	}
    void OnMouseUp()
    {
        
        SceneManager.LoadScene("map_1_2");
                
        /*
        Destroy(gameObject);
        Vector3 map_tr =new Vector3 (0,0,0);
		Vector3 wall_tr =new Vector3 (8.5f,-1,0);
		Instantiate(map,map_tr , transform.rotation);
		Instantiate(wall,wall_tr , transform.rotation);
        destroy_bot.destroy_parameter = 1;//很詭異的方式砍掉物件 太吃資源
        */
        
    }
}
