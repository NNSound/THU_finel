using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_ground : MonoBehaviour {
    Vector3 setGround=new Vector3 (0,0,0);
    Vector3 firstGround = new Vector3(-4, 2, 0);
    public GameObject ground;
    public GameObject pointer;

    // Use this for initialization
    void Start () {
        Instantiate(pointer, firstGround, transform.rotation);
        for (int i = 0; i < 9; i++){
            for (int j = 0; j < 2; j++){
                setGround = new Vector3(-4f + i, 2 - j, 0);
                Instantiate(ground, setGround, transform.rotation);
            }
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                setGround = new Vector3(-4f + i, -1 - j, 0);
                Instantiate(ground, setGround, transform.rotation);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

       
	}
}
