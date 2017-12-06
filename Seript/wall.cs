using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col)
	{
	if (col.tag == "Alive")
		{
			Destroy(col.gameObject);
		}
	}
}
