using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class make_map : MonoBehaviour {
	//說明:方便開發設計地圖之腳本
    Vector3 setGround = new Vector3(0, 0, 0);
    public GameObject ground;
    public Sprite[] sprFloors;
    
    float s_width;
    float s_height;
    // Use this for initialization
    void Start () {
        
        
        for (int i = 0; i < 16; i++) {
            for (int j = 0; j < 9; j++) {
                setGround = new Vector3(-7.5f+i, -4f+j, 0);
                GameObject newfloor =  Instantiate(ground, setGround, transform.rotation);
                newfloor.transform.parent = gameObject.transform;
                newfloor.AddComponent<makePath>();
                newfloor.AddComponent<BoxCollider2D>();
                newfloor.AddComponent<floorInfo>();
                newfloor.GetComponent<SpriteRenderer>().sprite = sprFloors[Random.Range(0,8)];
                newfloor.transform.localScale = new Vector3(0.4f,0.4f,0);
                var setpos =newfloor.GetComponent<floorInfo>();
                setpos.x=i;setpos.y=j;
            }
        }
        gameObject.transform.localScale = new Vector3(0.6f,0.6f,0);
	}
    


}
