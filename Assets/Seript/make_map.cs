﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_map : MonoBehaviour {
    Vector3 setGround = new Vector3(0, 0, 0);
    public GameObject ground;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 16; i++) {
            for (int j = 0; j < 9; j++) {
                setGround = new Vector3(i, j, 0);
                Instantiate(ground, setGround, transform.rotation);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}