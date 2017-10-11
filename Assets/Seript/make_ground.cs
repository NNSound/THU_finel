using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_ground : MonoBehaviour {
    
    Vector3 setGround=new Vector3 (0,0,0);
    Vector3 firstGround = new Vector3(-4, 2, 0);
    Vector3 ui_all_position = new Vector3(0.054f, -3.772f, 0);
    public GameObject pointer;
    public GameObject pointer_background;
    public GameObject ground;
    public GameObject ui_all;
    public static float x = -4, y = 2.75f;//指標的xy座標
    // Use this for initialization
    void Start () {
        Instantiate(pointer, firstGround, transform.rotation);
        Instantiate(pointer_background, firstGround, transform.rotation);
        Instantiate(ui_all, ui_all_position, transform.rotation);
    }	
	// Update is called once per frame
	void Update () {

       
	}
}
