using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour {
    //掛載物件:Tower
	//調用物件:null
	//說明:Tower之圖層前後設定
    float sortingOrder;
    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
            if (sprite){
                sortingOrder = transform.parent.position.y;                
                print (sortingOrder);                
                sprite.sortingOrder = 4-(int)sortingOrder;
            }
        
    }
	
}
