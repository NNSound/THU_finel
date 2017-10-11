using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointer_move : MonoBehaviour {

    float A = 0.5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            gameObject.transform.position += new Vector3(1, 0, 0);
            make_ground.x+=0.5f;
            print(make_ground.x);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-1, 0, 0);
            make_ground.x-=0.5f;
            print(make_ground.x);

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.position += new Vector3(0, 1, 0);
            make_ground.y+=0.5f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.position += new Vector3(0, -1, 0);
            make_ground.y-=0.5f;
        }

    }
}
