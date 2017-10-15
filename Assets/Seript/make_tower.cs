using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_tower : MonoBehaviour {

    public GameObject tower;
    public GameObject tower_1;
    public GameObject tower_2;
    private System.Boolean have_tower = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) /* && !have_tower */) {
            have_tower = true;
            print("something happen");
            Vector3 setTower = new Vector3(make_ground.x, make_ground.y, 0);
            GameObject newtower =Instantiate(tower, setTower, transform.rotation);
            /*
            GameObject child_tower =Instantiate(tower, setTower, transform.rotation);
            child_tower.transform.parent = gameObject.transform;
            */
        
            if (make_ground.y <2.75)
            {
                var myRenderer = newtower.GetComponent<SpriteRenderer>();
                int a = Mathf.FloorToInt(make_ground.y - 2.75f)*-1;
                myRenderer.sortingOrder = a;
            }

        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 setTower = new Vector3(make_ground.x, make_ground.y, 0);
            Instantiate(tower_1, setTower, transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Vector3 setTower = new Vector3(make_ground.x, make_ground.y, 0);
            Instantiate(tower_2, setTower, transform.rotation);
        }
    }    

}

