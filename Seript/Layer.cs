using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour {
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
	
	// Update is called once per frame
	void Update () {
       
    }
}
