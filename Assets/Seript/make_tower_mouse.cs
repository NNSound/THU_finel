using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_tower_mouse : MonoBehaviour {
    public GameObject tower;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseUp()
    {
        Vector3 me = gameObject.transform.localPosition;
        Instantiate(tower, me, transform.rotation);
    }
}
