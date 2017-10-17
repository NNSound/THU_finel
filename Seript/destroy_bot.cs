using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_bot : MonoBehaviour {
    // 這東西我想刪掉 因為切換場景會直接砍掉物件
    public static float destroy_parameter = 0;
    void Start () {
		
	}
	void Update () {
        if (destroy_parameter == 1)
        {
            Destroy(gameObject);
        }
	}
}
