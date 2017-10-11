using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wall : MonoBehaviour {
    public static int i = 0;//進入終點的數量 wall.i
                     // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Alive")
        {
            i++;
            print("pass : "+i);
            Destroy(col.gameObject);            
            score.Instance.AddScore();
        }
       
    }
}
