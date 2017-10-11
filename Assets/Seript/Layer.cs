using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var myRenderer = GetComponent<SpriteRenderer>();
        if (myRenderer.sortingOrder == 0)
        {
            // This is a new object
            myRenderer.sortingOrder = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
