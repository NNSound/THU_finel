using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_tower_mouse : MonoBehaviour {
    public GameObject tower;
    bool haveTower = false;
    // Use this for initialization
    void OnMouseUp()
    {
        if (!haveTower){
            haveTower = true;
            Vector3 me = transform.position;
            GameObject childTower =  Instantiate(tower, me, transform.rotation);
            childTower.transform.parent = transform;  
        }
        
    }
}
