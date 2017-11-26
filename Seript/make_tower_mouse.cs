using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_tower_mouse : MonoBehaviour {
    //掛載物件:ground_squire_obj
	//調用物件:null
	//說明:在方格上建立塔座
    bool haveTower = false;
    public gameSystem Sys;
    // Use this for initialization
    void OnMouseUp()
    {
        Sys = GetComponentInParent<gameSystem>();
        if (!haveTower){
            haveTower = Sys.makeTowerPanel(gameObject);
        }
        
    }
}
