using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSystem : MonoBehaviour {
	//掛載物件:Map
	//調用物件:ground_squire_obj(Clone)<make_tower_mouse>、tower_white<Button>、tower_red<Button>、tower_pup<Button>、tower_blk<Button、
	//說明:存放副程式以方便Button調用與維護
	public GameObject Makepanel;
	private GameObject floor;
	public GameObject isSelect;
	public make_tower_mouse mtm;
	
	public bool makeTowerPanel(GameObject obj){
		//print ("makeTowerPanel");
		Makepanel.gameObject.SetActive(true);
		floor = obj;
		return true;
	}
	public void makeTower(GameObject tower){
            Vector3 me = floor.transform.position;
            GameObject childTower =  Instantiate(tower, me, transform.rotation);
            childTower.transform.parent = floor.transform;
			Makepanel.gameObject.SetActive(false);
        
	}
	public void hightlight(GameObject obj){
		obj.transform.GetChild(0).gameObject.SetActive(true);
	}
	
}
